using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { MainMenu, GamePlay, Pause, Resume, GameOver, Finish }
public class GameManager : Singleton<GameManager>
{
    public GameObject PauseScreen;
    public GameObject GameOverScreen;
    private GameState gameState;
    private void Awake()
    {
        Application.targetFrameRate = 30;
        Input.multiTouchEnabled = false;
    }
    private void Start() => ChangeState(GameState.MainMenu);
    public void ChangeState(GameState gameState)
    {
        this.gameState = gameState;

        switch (gameState)
        {
            case GameState.MainMenu:
                MainMenu();
                break;
            case GameState.GamePlay:
                GamePlay();
                break;
            case GameState.Pause:
                PauseGame();
                break;
            case GameState.Resume:
                PauseGame();
                break;
            case GameState.GameOver:
                GameOver();
                break;
            case GameState.Finish:
                FinishGame();
                break;
        }

    }
    private void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        ChangeState(GameState.MainMenu);
    }
    private void GamePlay()
    {
        SceneManager.LoadScene("GamePlay");
        ChangeState(GameState.GamePlay);
    }
    private void PauseGame()
    {
        PauseScreen.SetActive(true);
        ChangeState(GameState.Pause);
    }
    private void GameOver()
    {

        ChangeState(GameState.GameOver);
    }
    public void FinishGame()
    {
        CameraFollow.Ins.offset = new Vector3(0, 8f, -4f);
        ChangeState(GameState.Finish);
    }


}

