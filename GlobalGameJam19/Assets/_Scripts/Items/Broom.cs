using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : ItemObject
{
    protected Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Dirt dirt = other.GetComponent<Dirt>();

        if (dirt != null)
        {
            dirt.Collect();
        }
    }

    public override bool Grab(Transform parent = null, PlayerGrab player = null)
    {
        bool reslt = base.Grab(parent, player);
        animator.SetBool("used", true);
        //foreach(Collider col in colliders)
        //{
        //    col.enabled = true;
        //}
        return reslt;
    }

    public override void Drop(PlayerGrab player = null)
    {
        animator.SetBool("used", false);
        base.Drop(player);
    }
}