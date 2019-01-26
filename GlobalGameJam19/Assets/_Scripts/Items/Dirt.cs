using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Dirt : MonoBehaviour
{
    bool collected;
    public void Collect()
    {
        if (!collected)
        {
            collected = true;
            transform.DOScale(Vector3.zero, .5f).OnComplete(delegate { Destroy(gameObject); });
        }
    }
}