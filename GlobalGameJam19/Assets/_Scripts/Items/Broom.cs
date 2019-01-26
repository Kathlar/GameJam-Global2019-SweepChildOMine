using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : ItemObject
{
    protected Animator animator;
    protected Dictionary<Dirt, float> dirts = new Dictionary<Dirt, float>();
    public float speed = 1;

    protected AudioSource sweepSound;

    private void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        sweepSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        List<Dirt> dirtsToDestroy = new List<Dirt>();
        List<Dirt> keys = new List<Dirt>(dirts.Keys);
        foreach (Dirt key in keys)
        {
            if (dirts[key] == null) break;
            dirts[key] += Time.deltaTime * speed;
            if (dirts[key] >= 1)
            {
                dirtsToDestroy.Add(key);
                key.Collect();
            }
        }
        foreach(var dirt in dirtsToDestroy)
        {
            dirts.Remove(dirt);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Dirt dirt = other.GetComponent<Dirt>();

        if (dirt != null && !dirts.ContainsKey(dirt))
        {
            dirts.Add(dirt, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Dirt dirt = other.GetComponent<Dirt>();

        if (dirt != null && dirts.ContainsKey(dirt))
        {
            dirts.Remove(dirt);
        }
    }

    public override bool Grab(Transform parent = null, PlayerGrab player = null)
    {
        sweepSound.Play();
        bool reslt = base.Grab(parent, player);
        if(animator != null)
            animator.SetBool("used", true);
        //foreach(Collider col in colliders)
        //{
        //    col.enabled = true;
        //}
        return reslt;
    }

    public override void Drop(PlayerGrab player = null)
    {
        sweepSound.Stop();
        if (animator != null)
            animator.SetBool("used", false);
        base.Drop(player);
    }
}