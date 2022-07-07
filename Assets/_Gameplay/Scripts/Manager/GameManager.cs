using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState { MainMenu, GamePlay, GameOver, Finish }
public class GameManager : Singleton<GameManager>
{
    public GameObject GameOverScreen;

    public Text GameOver;
    public GameState gameState;
    public ParticleSystem winExplosion1;
    public ParticleSystem winExplosion2;
    public GameObject chestOpen;
    public GameObject chestClose;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Input.multiTouchEnabled = false;
    }
    private void Start() => ChangeState(GameState.MainMenu);
    public void ChangeState(GameState gameState)
    {
        this.gameState = gameState;

        switch (gameState)
        {
            case GameState.MainMenu:

                break;
            case GameState.GamePlay:

                break;
            case GameState.Finish:
                FinishGame();
                break;
        }

    }

    public void FinishGame()
    {
        GameOverScreen.SetActive(true);
        CameraFollow.Ins.offset = new Vector3(0, 8f, -4f);
        GameOver.text = "YOUR STACKS: " + Stack.Ins.Tail.Count;
        winExplosion1.Play();
        winExplosion2.Play();
        chestOpen.SetActive(true);
        chestClose.SetActive(false);
    }
}

