using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	private static GameManager instance;
	public static GameManager Instance { get { return instance; } }

	public bool m_IsGameOver = false;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Destroy(this);
	}

    public List<LevelManager> levels;
    public Canvas canvas;
    public Text EndGameText;
    LevelManager currentLevel;
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
			m_IsGameOver = false;
			currentLevel = Instantiate(levels[level - 1]) as LevelManager;
            currentLevel.SetGameManager(this);
            canvas.enabled = false;
        }
    }

    public void GameOver(bool won)
	{
		m_IsGameOver = true;
		if (won)
            EndGameText.text = "Victoire !";
        else
        {
            Destroy(currentLevel.gameObject);
            EndGameText.text = "Défaite...";
        }
        canvas.enabled = true;
    }
}
