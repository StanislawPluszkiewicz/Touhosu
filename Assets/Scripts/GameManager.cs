using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<LevelManager> levels;
    public Canvas canvas;
    public Text EndGameText;
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
        if (levels.Count == 0)
            return;
        if(level <= levels.Count && level > 0)
        {
            LevelManager lm = Instantiate(levels[level - 1]) as LevelManager;
            lm.SetGameManager(this);
            canvas.enabled = false;
        }
    }

    public void GameOver(bool won)
    {
        if (won)
            EndGameText.text = "Tu as gagné !";
        else
            EndGameText.text = "Perdu...";
        canvas.enabled = true;
    }
}
