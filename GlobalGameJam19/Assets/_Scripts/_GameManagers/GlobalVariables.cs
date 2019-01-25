using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : ASingleton<GlobalVariables>
{
    public Canvas mainCanvas;
    public Camera mainCamera;

    private void Start()
    {
        if (mainCamera == null) mainCamera = Camera.main;
    }
}
