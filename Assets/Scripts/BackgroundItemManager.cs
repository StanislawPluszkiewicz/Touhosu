
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundItemManager : MonoBehaviour
{
    public float speed = 30f;
    private float DeathStamp;
    private float Lifespan = 30f;

    void Start()
    {
        DeathStamp = Time.time + Lifespan;
        speed /= (3f - transform.localScale.x);
    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, 20f);
        if (Time.time >= DeathStamp)
            Destroy(gameObject);
    }
}
