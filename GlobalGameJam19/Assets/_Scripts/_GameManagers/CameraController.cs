using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController currentCamera;
    protected List<Transform> objectsToFollow;
    protected bool setup;
    protected Vector3 offset;
    protected float offsetLength = 1;

    void Awake()
    {
        currentCamera = this;
    }

    void Start()
    {
        offset = transform.position;
    }

    void Update()
    {
        if (setup)
        {
            ChangePosition();
        }
    }

    public void SetObjectToFollow(List<Transform> objects)
    {
        objectsToFollow = objects;
        setup = true;
    }

    private Vector3 newPosition;
    void ChangePosition()
    {
        if (objectsToFollow.Count > 0)
        {
            float minX, maxX, minZ, maxZ;

            minX = maxX = objectsToFollow[0].position.x;
            minZ = maxZ = objectsToFollow[0].position.z;

            for (int i = 1; i < objectsToFollow.Count; i++)
            {
                float x = objectsToFollow[i].position.x, z = objectsToFollow[i].position.z;

                if (x < minX) minX = x;
                if (x > maxX) maxX = x;
                if (z < minZ) minZ = z;
                if (z > maxZ) maxZ = z;
            }

            newPosition = new Vector3((minX + maxX) / 2, 0, (minZ + maxZ) / 2);

            float difference = Mathf.Max(Mathf.Abs(minX - maxX), Mathf.Abs(minZ - maxZ));

            offsetLength = Mathf.Clamp(1 + (difference - 10) / 10, 1, 2);

            transform.position = newPosition + offset * offsetLength;
        }
    }
}
