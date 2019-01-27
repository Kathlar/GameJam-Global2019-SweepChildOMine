using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class VideoOnEndDestroy : MonoBehaviour
{
    public RawImage raw;


    private void Start()
    {
        Invoke("DoAlfa", 4);
        Invoke("DoDestroy", 5);
    }

    void DoAlfa()
    {
        raw.DOColor(new Color(0, 0, 0, 0), .8f);
    }
    
    void DoDestroy()
    {
        Destroy(gameObject);
    }
}
