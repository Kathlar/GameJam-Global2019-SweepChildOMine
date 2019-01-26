using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class PauseManager : ASingleton<PauseManager>
{
    bool gamePaused;
    public GameObject pauseMenu;

    private void Start()
    {
        if (pauseMenu != null) pauseMenu.SetActive(false);
    }

    public static void TryPause(bool showMenu = false)
    {
        if (Instance.gamePaused) UnpauseGame(showMenu);
        else PauseGame(showMenu);
    }

    public static void PauseGame(bool showMenu = false)
    {
        Instance.gamePaused = true;
        foreach(IPausable pause in FindObjectsOfType<MonoBehaviour>().OfType<IPausable>())
        {
            pause.Pause();
        }
        if (showMenu && Instance.pauseMenu != null) Instance.pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public static void UnpauseGame(bool hideMenu = true)
    {
        Instance.gamePaused = false;
        foreach (IPausable pause in FindObjectsOfType<MonoBehaviour>().OfType<IPausable>())
        {
            pause.Unpause();
        }
        if (hideMenu && Instance.pauseMenu != null) Instance.pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void UnpauseTheGame()
    {
        UnpauseGame(true);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
