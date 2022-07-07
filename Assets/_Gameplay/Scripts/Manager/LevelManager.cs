using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
    public int unitySceneIndex;
    public string levelDisplayIndex;
    public string levelName;

    public Animator transition;
    public Text levelNameText;

    public float transitionTime = 1f;

    public void SetText()
    {
        if (!string.IsNullOrEmpty(levelName))
        {
            if (levelName != null)
            { levelNameText.text = levelName; }

        }
    }

    [System.Obsolete]
    public void PlayAgainLevel()
    {
        Application.LoadLevel(unitySceneIndex);
        StartCoroutine(LoadLevelTransition(unitySceneIndex));
        GameManager.Ins.ChangeState(GameState.GamePlay);
    }
    [System.Obsolete]
    public void NextLevel()
    {
        GameManager.Ins.ChangeState(GameState.GamePlay);
        Application.LoadLevel(unitySceneIndex + 1);
        StartCoroutine(LoadLevelTransition(unitySceneIndex + 1));
    }
    [System.Obsolete]
    public void BackMenu()
    {
        GameManager.Ins.ChangeState(GameState.MainMenu);
        Application.LoadLevel(0);
        StartCoroutine(LoadLevelTransition(unitySceneIndex));
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    void Start()
    {
        SetText();
    }
    IEnumerator LoadLevelTransition(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
    }
}
