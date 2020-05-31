using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)
        {
            gm.GameOver(true);
            Destroy(gameObject);
        }
    }

    public void SetGameManager(GameManager manager)
    {
        gm = manager;
    }
}
