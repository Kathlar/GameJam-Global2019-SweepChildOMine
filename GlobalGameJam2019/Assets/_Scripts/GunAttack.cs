using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAttack : AAttack
{
    protected LineRenderer line;
    public Transform shootPoint;

    void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    void Start()
    {
        line.positionCount = 2;
    }

    void Update()
    {
        line.SetPosition(0, shootPoint.position);

        Ray ray = new Ray(shootPoint.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            line.SetPosition(1, hit.point);
        }
        else
        {
            line.SetPosition(1, shootPoint.position + transform.forward * 1000);
        }
    }

    protected override void DoAttack()
    {
        GameObject projectile = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        //Projectile projectile = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation).GetComponent<Projectile>();
    }
}
