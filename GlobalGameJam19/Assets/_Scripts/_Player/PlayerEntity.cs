using System.Collections;
using System.Collections.Generic;
using InControl;
using UnityEngine;

public class PlayerEntity
{
    public enum PlayerControllerType
    {
        Keyboard, Pad
    }
    public PlayerControllerType controllerType;

    public static Dictionary<PlayerControllerType, int> NumbersOfPlayersOfType;
    public static List<PlayerEntity> Entities;
    [HideInInspector] public int numberOfControllerType = 0;
    [HideInInspector] public InputDevice inputDevice;

    public PlayerEntity(PlayerControllerType controllerType, InputDevice device = null)
    {
        this.controllerType = controllerType;

        if (NumbersOfPlayersOfType == null) NumbersOfPlayersOfType = new Dictionary<PlayerControllerType, int>();
        if (!NumbersOfPlayersOfType.ContainsKey(controllerType)) NumbersOfPlayersOfType.Add(controllerType, 0);

        if (Entities == null) Entities = new List<PlayerEntity>();
        if (!Entities.Contains(this)) Entities.Add(this);

        numberOfControllerType = NumbersOfPlayersOfType[controllerType];
        NumbersOfPlayersOfType[controllerType]++;

        if(controllerType == PlayerControllerType.Pad && numberOfControllerType < InputManager.Devices.Count)
            inputDevice = InputManager.Devices[numberOfControllerType];
    }
}
