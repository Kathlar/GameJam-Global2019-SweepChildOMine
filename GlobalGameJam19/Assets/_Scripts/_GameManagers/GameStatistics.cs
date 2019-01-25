using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatistics : MonoBehaviour
{
    public Text numberOfPointsText;

    protected static GameStatistics Instance;
    public int numberOfPoints = 0;

    void Awake()
    {
        Instance = this;
        if(numberOfPointsText != null)
            numberOfPointsText.text = "0";
    }

    public static void AddPoints(int points)
    {
        Instance.numberOfPoints += points;
        if (Instance.numberOfPointsText != null)
            Instance.numberOfPointsText.text = Instance.numberOfPoints.ToString();
    }
}
