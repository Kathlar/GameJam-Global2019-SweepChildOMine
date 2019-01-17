using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 50;
    protected int currentHealth;

    protected Vector3 startPosition;

    protected int numberOfDeaths;

    void Start()
    {
        currentHealth = maxHealth;
        startPosition = transform.position;
    }
    
    public void GetDamage(int value)
    {
        currentHealth = Mathf.Clamp(currentHealth - value, 0, currentHealth);
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
