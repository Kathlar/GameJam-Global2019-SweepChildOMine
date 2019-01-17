using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthBar;
    protected RectTransform healthBarTransform;

    public int maxHealth = 50;
    protected int currentHealth;

    protected Vector3 startPosition;

    protected int numberOfDeaths;

    void Awake()
    {
        healthBarTransform = healthBar.transform.parent.GetComponent<RectTransform>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        startPosition = transform.position;
    }

    void LateUpdate()
    {
        healthBarTransform.position = Camera.main.WorldToScreenPoint(transform.position + transform.up * 2);
    }
    
    public void GetDamage(int value)
    {
        currentHealth = Mathf.Clamp(currentHealth - value, 0, currentHealth);
        healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {
        currentHealth = maxHealth;
        transform.position = startPosition;
        numberOfDeaths--;
    }
}
