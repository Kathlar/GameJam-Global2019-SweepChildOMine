using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strecher : AInteractive
{
    protected LineRenderer line;

    public Transform strecthIncomePlace;
    public float strechSpeed = .2f;
    protected Dictionary<ItemObject, float> StrechProgress = new Dictionary<ItemObject, float>();

    void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    void Start()
    {
        base.Start();
        line.positionCount = 2;
        line.SetPosition(0, strecthIncomePlace.transform.position);
        line.SetPosition(1, transform.position);
    }

    private void Update()
    {
        base.Update();
        if(itemOn != null)
        {
            if (!StrechProgress.ContainsKey(itemOn)) StartStreching();
            else KeepStreching();
        }
    }

    void StartStreching()
    {
        StrechProgress.Add(itemOn, 0);

        progressBar.Show();
        line.SetPosition(1, itemOn.transform.position);
    }

    void KeepStreching()
    {
        if (StrechProgress[itemOn] >= 1) return;
        itemOn.transform.Rotate(0, 1, 0);
        StrechProgress[itemOn] += strechSpeed * Time.deltaTime;
        if (StrechProgress[itemOn] >= 1) EndStreching();

        progressBar.SetValue(StrechProgress[itemOn]);
    }

    void EndStreching()
    {
        itemOn.renderer.material = MaterialDatabase.Instance.M_Strech;

        PackageObject package = itemOn.GetComponent<PackageObject>();

        if (package != null) package.RepairCondition();

        progressBar.Hide();
        line.SetPosition(1, transform.position);
    }
}
