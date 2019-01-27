using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ParentsMsgs : ASingleton<ParentsMsgs>
{
    string text1 = "Hey guys! Me and papa will be back soon. I hope everything is clean ;)";
    string text2 = "We're already in town, so expect us any minute :)";

    public RectTransform hiddenPos, normalPos;
    public RectTransform msgTrans;
    public TextMeshProUGUI text;

    public AudioSource sound;

    private void Start()
    {
        msgTrans.position = hiddenPos.position;
        ShowMessage(text1, 3f);
    }

    public static void ShowMessage(string msg, float delay)
    {
        Instance.StartCoroutine(Instance.ShowMessageCoroutine(msg, delay));
    }

    IEnumerator ShowMessageCoroutine(string msg, float delay)
    {
        yield return new WaitForSeconds(delay);
        sound.Play();
        text.text = msg;
        msgTrans.DOMove(normalPos.position, 1);
        yield return new WaitForSeconds(8);
        msgTrans.DOMove(hiddenPos.position, 1);

        if (msg == text1)
        {
            GameStats.StartTimer();
            float timeLeft = GameStats.Instance.timeLeft - 30;
            if (timeLeft > 30)
                ShowMessage(Instance.text2, timeLeft);
        }
    }
}
