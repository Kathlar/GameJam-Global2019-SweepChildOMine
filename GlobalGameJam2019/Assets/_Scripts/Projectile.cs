using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int attackPower = 5;
    public float moveSpeed = 15f;

    void FixedUpdate()
    {
        transform.position += transform.forward * moveSpeed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        Health health = other.transform.GetComponent<Health>();

        if (health != null)
        {
            Hit(health);
        }
        HitEffect();
    }

    void Hit(Health health)
    {
        health.GetDamage(attackPower);
    }

    void HitEffect()
    {
        Destroy(gameObject);
    }
}
