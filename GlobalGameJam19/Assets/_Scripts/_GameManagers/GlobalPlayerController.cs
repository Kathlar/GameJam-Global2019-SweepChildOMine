using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class GlobalPlayerController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) PauseManager.TryPause(true);

        if (InputManager.ActiveDevice.CommandWasPressed) FindObjectOfType<PlayerChoosingMenu>().StartGame();
    }
}
