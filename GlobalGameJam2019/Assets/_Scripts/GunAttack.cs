using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAttack : AAttack
{
    public Transform shootPoint;

    protected override void DoAttack()
    {
        GameObject projectile = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        //Projectile projectile = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation).GetComponent<Projectile>();
    }
}
