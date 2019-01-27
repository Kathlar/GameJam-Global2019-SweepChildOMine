using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerSpawnManager))]
public class CustomPlayerSpawner : MonoBehaviour
{
    public static List<DebugPlayerSpawnInformation> customInfo;
    public List<DebugPlayerSpawnInformation> debugPlayerSpawnInfo;

    private void Start()
    {
        if (customInfo != null && customInfo.Count > 0) debugPlayerSpawnInfo = customInfo;
    }

    public void SetPlayerInfo()
    {
        foreach (DebugPlayerSpawnInformation info in debugPlayerSpawnInfo)
        {
            PlayerEntity playerEntity = new PlayerEntity(info.controllerType);
        }
        GameStats.Instance.timeLeft /= debugPlayerSpawnInfo.Count;
    }
}

[Serializable]
public class DebugPlayerSpawnInformation
{
    public int forcedNumber;
    public PlayerEntity.PlayerControllerType controllerType;

    public DebugPlayerSpawnInformation(PlayerEntity.PlayerControllerType controllerType)
    {
        this.controllerType = controllerType;
    }
}
