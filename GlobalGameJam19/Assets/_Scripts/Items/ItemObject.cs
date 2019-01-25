using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [HideInInspector] public MeshRenderer renderer;
    protected Collider collider;
    protected Rigidbody rb;
    protected Transform originalParent;

    [HideInInspector] public bool grabbed;

    public float minScale = .8f, maxScale = 1.3f;

    void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
        collider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        originalParent = transform.parent;

        float scale = Random.Range(minScale, maxScale);
        float scaleMulti = Random.Range(minScale, maxScale);
        transform.localScale = new Vector3(scale, scale * scaleMulti, scale/scaleMulti);
    }

    public void Grab(Transform parent = null)
    {
        if (parent != null) transform.SetParent(parent);

        grabbed = true;
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        if (collider != null) collider.enabled = false;
    }

    public void Drop()
    {
        transform.SetParent(originalParent);

        grabbed = false;
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }

        if (collider != null) collider.enabled = true;
    }
}
