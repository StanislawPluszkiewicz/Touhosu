using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<LevelManager> levels;
    public Canvas canvas;



    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canvas.enabled)
            QuitApplication();
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void LoadLevel(int level)
    {
        if(level <= levels.Count && level > 0)
        {
            Instantiate(levels[level - 1]);
            canvas.enabled = false;
        }
    }

    public void GameOver(bool won)
    {
        canvas.enabled = true;
    }
}
