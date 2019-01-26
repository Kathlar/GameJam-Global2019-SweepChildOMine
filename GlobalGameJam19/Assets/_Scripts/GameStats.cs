using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStats : MonoBehaviour
{
    public TextMeshProUGUI timeLeftText;
    public float timeLeft = 300;

    bool gameEnded = false;

    private void Update()
    {
        if (gameEnded) return;
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0)
        {
            EndGame();
        }
        timeLeftText.text = GetTimeInMinutes();
    }

    string GetTimeInMinutes()
    {
        float minutesLeft = Mathf.Floor(timeLeft / 60);
        if (timeLeft == 0) return "";
        else if (minutesLeft > 0)
            return minutesLeft.ToString() + "m " + (Mathf.Floor(timeLeft - minutesLeft * 60)).ToString() + "s";
        else
            return timeLeft + "s";
    }

    void EndGame()
    {
        gameEnded = true;
        timeLeft = 0;
        timeLeftText.text = GetTimeInMinutes();
    }
}
