using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum GameState {GAME, PAUSE_MENU, LEVEL_COMPLETED}
public class GameManager : MonoBehaviour
{
    public GameState currentGameState = GameState.PAUSE_MENU;
    public static GameManager instance;
    
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

    }

    void SetGameState(GameState newGameState)
    {
        currentGameState = newGameState;
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
