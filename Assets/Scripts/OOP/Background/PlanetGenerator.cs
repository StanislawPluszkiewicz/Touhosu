using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour
{
    [SerializeField] float MinTimeBetweenPlanets = 3f;
    [SerializeField] float MaxTimeBetweenPlanets = 10f;
    [SerializeField] GameObject PlanetPrefab;
    [SerializeField] float YSpawn = 100f;
    [SerializeField] float MinXSpawn = -100f;
    [SerializeField] float MaxXSpawn = 100f;

    private Random rng;
    // Start is called before the first frame update
    void Start()
    {
        rng = new Random();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
