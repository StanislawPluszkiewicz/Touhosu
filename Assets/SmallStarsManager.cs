using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallStarsManager : MonoBehaviour
{
    [Range(2, 10)]
    [SerializeField] private int StarGroupAmount = 2;
    [SerializeField] private float MinX = -50f;
    [SerializeField] private float MaxX = 50f;
    [SerializeField] float YSpawn = 100f;
    [SerializeField] float Interval = 45f;
    [SerializeField] GameObject StarsPrefab;
    [SerializeField] float LifespanStars = 30f;
    [SerializeField] float ErrorRandom = 10f;
    [SerializeField] float StarsScale = 3f;
	float nextSpawn = 0.0f;
    float inter;

	private void Awake()
	{
		nextSpawn = Time.time;
	}

	private void Start()
    {
        inter = (MaxX - MinX) / (StarGroupAmount - 1f);
        for (int i = 0; i < StarGroupAmount; i++)
        {
            GameObject group = Instantiate(StarsPrefab, new Vector3(MinX + inter * i + Helper.RandomBetweenFloats(0, ErrorRandom), YSpawn / 2 + Helper.RandomBetweenFloats(-ErrorRandom, ErrorRandom), 15f), Quaternion.identity, transform);
            group.AddComponent<BackgroundItemManager>();
            BackgroundItemManager bim = group.GetComponent<BackgroundItemManager>();
            group.transform.localScale *= StarsScale;
            bim.Lifespan = LifespanStars;
        }
        for (int i = 0; i < StarGroupAmount; i++)
        {
            GameObject group = Instantiate(StarsPrefab, new Vector3(MinX + inter * i + Helper.RandomBetweenFloats(0, ErrorRandom), -YSpawn / 2 + Helper.RandomBetweenFloats(ErrorRandom, ErrorRandom), 15f), Quaternion.identity, transform);
            group.AddComponent<BackgroundItemManager>();
            BackgroundItemManager bim = group.GetComponent<BackgroundItemManager>();
            group.transform.localScale *= StarsScale;
            bim.Lifespan = LifespanStars / 2;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSpawn)
        {
            nextSpawn = Time.time + Interval;
            for (int i = 0; i < StarGroupAmount; i++)
            {
                GameObject group = Instantiate(StarsPrefab, new Vector3(MinX + inter * i + Helper.RandomBetweenFloats(0, ErrorRandom), YSpawn, 15f), Quaternion.identity, transform);
                group.AddComponent<BackgroundItemManager>();
                BackgroundItemManager bim = group.GetComponent<BackgroundItemManager>();
                group.transform.localScale *= StarsScale;
                bim.Lifespan = LifespanStars;
            }
        }
    }
}
