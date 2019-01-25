using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChanger : AInteractive
{
    public ProgressBar progressBar;

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
        progressBar.SetPosition(transform.position + transform.up * 3);
    }
}
