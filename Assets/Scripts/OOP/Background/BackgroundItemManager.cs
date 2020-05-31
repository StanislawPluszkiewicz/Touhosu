using UnityEngine;

public class BackgroundItemManager : MonoBehaviour
{
    public float Speed = 60f;
    private float deathStamp;
    public float Lifespan = 30f;

    void Start()
    {
        deathStamp = Time.time + Lifespan;
        Speed /= transform.localScale.x;
    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - Speed * Time.deltaTime, 20f);
        if (Time.time >= deathStamp)
            Destroy(gameObject);
    }
}
