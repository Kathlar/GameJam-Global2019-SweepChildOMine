using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChanger : Shelf
{
    public ProgressBar progressBar;
    public float itemChangeSpeed = .2f;

    protected virtual void Start()
    {
        progressBar = Instantiate(PrefabDatabase.Instance.progressBarPrefab, GlobalVariables.Instance.mainCanvas.transform).GetComponent<ProgressBar>();
        progressBar.Hide();
        progressBar.SetValue(0);
    }

    protected virtual void Update()
    {
        SetProgressBar();
    }

    protected virtual void SetProgressBar()
    {
        progressBar.SetPosition(transform.position + transform.up * 1.5f);
    }

    protected virtual void Finnish()
    {
        progressBar.Hide();
    }
}
