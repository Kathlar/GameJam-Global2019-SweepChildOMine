using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Camera camer;
    public Transform startPosition, playerPosition;
    public GameObject playerMenu;
    public static bool dupa;
    public Image blackoutImage;

    private void OnSceneLoad()
    {
        if(blackoutImage != null)
        {
            blackoutImage.gameObject.SetActive(true);
            blackoutImage.enabled = true;
            blackoutImage.DOColor(new Color(0, 0, 0, 0), 1.5f);
        }
    }

    public void PlayGame ()
    {
        camer.transform.DOMove(playerPosition.position, 1f);
        camer.transform.DORotate(playerPosition.eulerAngles, 1f).OnComplete(delegate { playerMenu.SetActive(true); FindObjectOfType<PlayerChoosingMenu>().presInfo.SetActive(true);
            dupa = true;
            playerMenu.SetActive(true);
        });
    }

    public void CancelPlay(bool move = true)
    {
        playerMenu.SetActive(false);
        if(move)
        {
            camer.transform.DOMove(startPosition.position, 1f);
            camer.transform.DORotate(startPosition.eulerAngles, 1f);
        }
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
