using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCollectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GunAttack gunAttack = other.GetComponent<GunAttack>();

        if (gunAttack)
        {
            gunAttack.enabled = true;
            Destroy(gameObject);
        }
    }
}
