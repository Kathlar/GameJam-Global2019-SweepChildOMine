using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public List<Transform> players;

    protected Vector3 offset;

    void Start()
    {
        offset = transform.position;
    }

    void LateUpdate()
    {
        float minX, maxX, minZ, maxZ;

        minX = maxX = players[0].transform.position.x;
        minZ = maxZ = players[0].transform.position.z;

        for (int i = 1; i < players.Count; i++)
        {
            float playerX = players[i].transform.position.x, playerZ = players[i].transform.position.z;

            if (playerX < minX) minX = playerX;
            if (playerX > maxX) maxX = playerX;
            if (playerZ < minZ) minZ = playerZ;
            if (playerZ > maxZ) maxZ = playerZ;
        }

        Vector3 newPosition = new Vector3((minX + maxX) / 2, 0, (minZ + maxZ) / 2);

        float distance = Vector3.Distance(players[0].transform.position, players[1].transform.position);
        float offsetLength = 1;
        if (distance > 10) offsetLength = 1 + (distance - 10) / 20;

        transform.position = newPosition + offset * offsetLength;
    }
}
