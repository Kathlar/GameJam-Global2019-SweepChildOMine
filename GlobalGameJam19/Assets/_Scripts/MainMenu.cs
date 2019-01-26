using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    public Camera camer;
    public Transform startPosition, playerPosition;
    public GameObject playerMenu;
    public static bool dupa;


    public void PlayGame ()
    {
        camer.transform.DOMove(playerPosition.position, 1f);
        camer.transform.DORotate(playerPosition.eulerAngles, 1f).OnComplete(delegate { playerMenu.SetActive(true); FindObjectOfType<PlayerChoosingMenu>().presInfo.SetActive(true);
            dupa = true;
            playerMenu.SetActive(true);
        });
    }

    public void CancelPlay()
    {
        playerMenu.SetActive(false);
        camer.transform.DOMove(startPosition.position, 1f);
        camer.transform.DORotate(startPosition.eulerAngles, 1f);
        dupa = false;
    }

    public void QuitGame ()
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
