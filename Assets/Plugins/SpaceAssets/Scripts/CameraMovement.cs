using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    //Set the speed that the camera moves through space
    public float cameraSpeed = 8f;
    float currentScrollPosition = 0f;

	void Start () {
        switch (SpaceManager.instance.scrollDirection)
        {
            case ScrollDirection.LeftToRight: case ScrollDirection.RightToLeft:
                currentScrollPosition = transform.position.x / cameraSpeed;
                break;
            case ScrollDirection.DownToUp: case ScrollDirection.UpToDown:
                currentScrollPosition = transform.position.y / cameraSpeed;
                break;
        }
    }
	
	void Update () {
        //Assign the current position using a variable to set the position
        currentScrollPosition += Time.deltaTime;
		transform.position = GetNewPosition(transform.position);
    }

	public Vector3 GetNewPosition(Vector3 pos)
	{
		Vector3 newPosition = Vector3.zero;
		//Set the new position based on the scroll direction and speed
		switch (SpaceManager.instance.scrollDirection)
		{
			case ScrollDirection.LeftToRight:
				newPosition = new Vector3(Mathf.Lerp(pos.x, cameraSpeed * currentScrollPosition, Time.deltaTime), pos.y, pos.z);
				break;
			case ScrollDirection.RightToLeft:
				newPosition = new Vector3(Mathf.Lerp(pos.x, -cameraSpeed * currentScrollPosition, Time.deltaTime), pos.y, pos.z);
				break;
			case ScrollDirection.DownToUp:
				newPosition = new Vector3(pos.x, Mathf.Lerp(pos.y, cameraSpeed * currentScrollPosition, Time.deltaTime), pos.z);
				break;
			case ScrollDirection.UpToDown:
				newPosition = new Vector3(pos.x, Mathf.Lerp(pos.y, -cameraSpeed * currentScrollPosition, Time.deltaTime), pos.z);
				break;
		}
		return newPosition;
	}
}
