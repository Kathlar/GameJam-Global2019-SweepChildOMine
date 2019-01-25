using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerSpawnManager))]
public class CustomPlayerSpawner : MonoBehaviour
{
    public List<DebugPlayerSpawnInformation> debugPlayerSpawnInfo;

    public void SetPlayerInfo()
    {
        foreach (DebugPlayerSpawnInformation info in debugPlayerSpawnInfo)
        {
            PlayerEntity playerEntity = new PlayerEntity(info.controllerType);
        }
    }
}

[Serializable]
public class DebugPlayerSpawnInformation
{
    public PlayerEntity.PlayerControllerType controllerType;
}
