using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    protected Image barBG;
    public Image bar;

    private void Awake()
    {
        barBG = GetComponent<Image>();
        Hide();
    }

    public void SetValue(float value)
    {
        bar.fillAmount = Mathf.Clamp(value, 0f, 1f);
    }

    public void SetValue(float currentValue, float maxValue)
    {
        bar.fillAmount = Mathf.Clamp(currentValue / maxValue, 0, 1);
    }

    public void Show()
    {
        barBG.enabled = true;
        bar.enabled = true;
    }

    public void Hide()
    {
        barBG.enabled = false;
        bar.enabled = false;
    }

    public void SetPosition(Vector3 inGamePosition)
    {
        transform.position = GlobalVariables.Instance.mainCamera.WorldToScreenPoint(inGamePosition);
    }
}
