using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AAttack : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float cooldown = .5f;
    protected float lastTimeOfAttack = 0;

    public void Attack()
    {
        if (Time.timeSinceLevelLoad > lastTimeOfAttack + cooldown)
        {
            lastTimeOfAttack = Time.timeSinceLevelLoad;
            DoAttack();
        }
    }

    protected abstract void DoAttack();
}
