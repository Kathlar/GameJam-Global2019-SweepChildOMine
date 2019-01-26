using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ItemObject : MonoBehaviour
{
    public ItemObjectType objectType = ItemObjectType.Other;
    public float status = 1;
    [HideInInspector] public MeshRenderer renderer;
    protected List<Collider> colliders;
    protected Rigidbody rb;
    protected Transform originalParent;

    [HideInInspector] public bool grabbed;
    [HideInInspector] public Shelf objectOn;

    public GameObject dirt;

    bool movingToPlayersHand;

    protected virtual void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
        colliders = new List<Collider>();
        foreach (Collider col in GetComponents<Collider>())
        {
            colliders.Add(col);
        }
        rb = GetComponent<Rigidbody>();
        originalParent = transform.parent;
    }

    private void Update()
    {
        if (movingToPlayersHand && (transform.parent == null || transform.parent == originalParent)) transform.DOKill();
    }

    public virtual bool Grab(Transform parent = null, PlayerGrab player = null)
    {
        if (parent != null) transform.SetParent(parent);

        grabbed = true;
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }
        if (colliders != null)
        {
            foreach (Collider col in colliders)
            {
                if (!col.isTrigger)
                    col.enabled = false;
            }
        }
        if (objectOn != null) objectOn.PutOff();
        return true;
    }

    public virtual void Drop(PlayerGrab player = null)
    {
        transform.SetParent(originalParent);

        grabbed = false;
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }

        if (colliders != null)
        {
            foreach (Collider col in colliders)
            {
                col.enabled = true;
            }
        }
    }

    public virtual void DoMove(Vector3 localPos, PlayerGrab player, float moveTime = .5f, float rotateTime = 1f)
    {
        movingToPlayersHand = true;
        transform.DOLocalMove(localPos, moveTime);
        transform.DOLocalRotate(localPos, rotateTime).OnComplete(delegate { movingToPlayersHand = false; player.inProgress = false; });
    }
}

public enum ItemObjectType
{
    Chair, Plate, Other, Trash, Cloth
}