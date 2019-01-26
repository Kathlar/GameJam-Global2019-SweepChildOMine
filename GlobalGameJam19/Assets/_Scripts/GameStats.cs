using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using DG.Tweening;

public class GameStats : MonoBehaviour
{
    public TextMeshProUGUI timeLeftText;
    public float timeLeft = 300;

    public float points, maxPoints;
    public List<ItemPosition> itemPositions;

    bool gameEnded = false;

    public GameObject statistiscView;
    public GameObject star1, star2, star3;

    private void Start()
    {
        CountMaxPoints();
        statistiscView.SetActive(false);
    }

    private void Update()
    {
        if (gameEnded) return;
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0)
        {
            EndGame();
        }
        if(timeLeftText!= null)
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
        CountPoints();
        statistiscView.SetActive(true);
        foreach(var cipa in FindObjectsOfType<PlayerController>())
        {
            cipa.enabled = false;
        }
        StartCoroutine(EndCoroutine());
    }

    IEnumerator EndCoroutine()
    {
        RectTransform dupsko = star1.GetComponent<RectTransform>();
        dupsko.localScale = Vector3.zero;
        yield return new WaitForSeconds(1f);
        star1.gameObject.SetActive(true);
        dupsko.DOScale(Vector3.one, .7f);

        dupsko = star2.GetComponent<RectTransform>();
        dupsko.localScale = Vector3.zero;
        if (points > .5f * maxPoints)
        {
            yield return new WaitForSeconds(1f);
            star2.gameObject.SetActive(true);
            dupsko.DOScale(Vector3.one, .7f);

            dupsko = star3.GetComponent<RectTransform>();
            dupsko.localScale = Vector3.zero;
            if (points > .6f * maxPoints)
            {
                yield return new WaitForSeconds(1f);
                star3.gameObject.SetActive(true);
                dupsko.DOScale(Vector3.one, .7f);
            }
        }
    }

    void CountPoints()
    {
        float numberOfPoints = 0;
        int test = 0;
        foreach (var item in itemPositions)
        {
            if (Vector3.Distance(item.obj.position, item.wantedPosition.position) < 1)
            {
                numberOfPoints++;
            }
        }
        foreach (var t in FindObjectsOfType<ItemObject>())
        {
            if (t.objectType == ItemObjectType.Plate)
            {
                test++;
            }
        }
        numberOfPoints += (float)(numberOfPlates - test);
        test = 0;
        foreach (var t in FindObjectsOfType<ItemObject>())
        {
            if (t.objectType == ItemObjectType.Trash)
            {
                test++;
            }
        }
        numberOfPoints += (float)(numberOfTrash - test);
        test = 0;
        foreach (var tr in FindObjectsOfType<Dirt>())
        {
            test++;
        }
        numberOfPoints += (float)(numberOfDirt - test) * .1f;
        points = numberOfPoints;
    }

    private int numberOfPlates = 0, numberOfTrash = 0, numberOfDirt = 0;
    void CountMaxPoints()
    {
        float numberOfPoints = 0;
        foreach(var item in itemPositions)
        {
            numberOfPoints++;
        }
        foreach(var t in FindObjectsOfType<ItemObject>())
        {
            if(t.objectType == ItemObjectType.Plate)
            {
                numberOfPoints++;
                numberOfPlates++;
            }
            if(t.objectType == ItemObjectType.Trash)
            {
                numberOfPoints++;
                numberOfTrash++;
            }
        }
        foreach(var tr in FindObjectsOfType<Dirt>())
        {
            numberOfPoints += .1f;
            numberOfDirt++;
        }
        maxPoints = numberOfPoints;
    }
}

[Serializable]
public class ItemPosition
{
    public Transform obj;
    public Transform wantedPosition;
}
