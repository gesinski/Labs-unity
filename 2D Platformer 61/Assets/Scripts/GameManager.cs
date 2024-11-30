using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public enum GameState {GAME, PAUSE_MENU, LEVEL_COMPLETED}
public class GameManager : MonoBehaviour
{
    public GameState currentGameState = GameState.PAUSE_MENU;
    public static GameManager instance;
    public Canvas inGameCanvas = null;
    public TMP_Text scoreText;
    public Image[] keysTab;
    private int keysFound = 0;
    public Image[] livesTab;
    private int Lives = 3;
    public TMP_Text timerText;
    private float elapsedTime = 0.0f;
    public TMP_Text enemiesKilledText;
    private int enemiesKilled = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else
        {
            Debug.LogError("Duplicated Game Manager", gameObject);
        }
        scoreText.text = "00";
        livesTab[3].enabled = false;
        for (int i = 0; i < 3; i++)
        {
            keysTab[i].color = Color.grey;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
           if (currentGameState == GameState.GAME)
            {
                SetGameState(GameState.PAUSE_MENU);
            }else if (currentGameState == GameState.PAUSE_MENU)
            {
                SetGameState(GameState.GAME);
            }
        }

        elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60); 

        string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        timerText.text = formattedTime;

    }

    void SetGameState(GameState newGameState)
    {
        currentGameState = newGameState;
        if (currentGameState == GameState.GAME)
        {
            inGameCanvas.enabled = true;
            Debug.Log("CanvasOdpalone");
        }
    }

    public void AddEnemiesKilled()
    {
        enemiesKilled++;
        if (enemiesKilled < 10)
        {
            enemiesKilledText.text = "0" + enemiesKilled.ToString();
        }
        else
        {
            enemiesKilledText.text = enemiesKilled.ToString();
        }
    }

    public void SubLives()
    {
        Lives--;
        livesTab[Lives].enabled = false;
    }

    public void AddLives()
    {
        Lives++;
        livesTab[Lives-1].enabled = true;
    }

    public void AddKeys()
    {
        keysFound++;
        keysTab[keysFound-1].color = Color.red;
    }

    public void AddPoints(int points)
    {
        if (points < 10)
        {
            scoreText.text = "0" + points.ToString();
        }
        else
        {
            scoreText.text = points.ToString();
        }
        
    }

    public void PauseMenu()
    {
        SetGameState(GameState.PAUSE_MENU);
    }

    public void InGame()
    {
        SetGameState(GameState.GAME);
    }

    public void GameOver()
    {
        SetGameState(GameState.LEVEL_COMPLETED);
    }

}
