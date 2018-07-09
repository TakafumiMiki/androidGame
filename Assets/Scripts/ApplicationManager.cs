using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApplicationManager : MonoBehaviour {
    public Button pauseButton;
    public Button restartButton;
    public void Quit()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
		Application.Quit();
    #endif
    }

    public void GameStart()
    {
        SceneManager.LoadScene("block");
    }

    public void GamePauseButton()
    {
        Time.timeScale = 0;
        pauseButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
    }

    public void GameRestartButton()
    {
        Time.timeScale = 1;
        restartButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }

    public void GameResult()
    {
        SceneManager.LoadScene("resultScene",LoadSceneMode.Additive);
    }

    public void ExitResult()
    {
        SceneManager.UnloadSceneAsync("resultScene");
    }

    public void GameRestart()
    {
        SceneManager.LoadScene("block");
    }

    public void GameCredit()
    {
        SceneManager.LoadScene("credit", LoadSceneMode.Additive);
    }
    public void ExitCredit()
    {
        SceneManager.UnloadSceneAsync("credit");
    }
}


