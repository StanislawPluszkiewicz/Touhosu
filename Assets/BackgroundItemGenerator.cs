using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundItemGenerator : MonoBehaviour
{
    [SerializeField] float MinTimeBetweenItems = 3f;
    [SerializeField] float MaxTimeBetweenItems = 10f;
    [SerializeField] GameObject ItemPrefab;
    [SerializeField] float YSpawn = 150f;
    [SerializeField] float MinXSpawn = -60f;
    [SerializeField] float MaxXSpawn = 60f;
    [SerializeField] float LifespanItems = 30f;

    float nextItem;
    
    // Start is called before the first frame update
    void Start()
    {
        nextItem = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextItem)
        {
            nextItem = Time.time + Helper.RandomBetweenFloats(MinTimeBetweenItems, MaxTimeBetweenItems);

            Vector3 spawnPosition = new Vector3(Helper.RandomBetweenFloats(MinXSpawn, MaxXSpawn), YSpawn, 0f);
            GameObject generatedItem = Instantiate(ItemPrefab, spawnPosition, Quaternion.identity, transform);
            generatedItem.AddComponent<BackgroundItemManager>();
            BackgroundItemManager bim = generatedItem.GetComponent<BackgroundItemManager>();
            bim.Lifespan = LifespanItems;

        }
    }
}
