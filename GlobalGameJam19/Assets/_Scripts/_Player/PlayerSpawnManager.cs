using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    private CustomPlayerSpawner customSpawner;

    public List<GameObject> playerPrefabs = new List<GameObject>();

    public List<Transform> spawnPoints;

    public List<PlayerAttributes> attributes;

    void Awake()
    {
        customSpawner = GetComponent<CustomPlayerSpawner>();

        if (spawnPoints == null || spawnPoints.Count == 0)
        {
            foreach (Transform child in GetComponentsInChildren<Transform>())
            {
                if (child != transform) spawnPoints.Add(child);
            }
        }
    }

    void Start()
    {
        if (customSpawner != null)
        {
            customSpawner.SetPlayerInfo();
        }

        List<Transform> playerTransforms = new List<Transform>();
        for (int i = 0; i < PlayerEntity.Entities.Count; i++)
        {
            PlayerController player = Instantiate(playerPrefabs[UnityEngine.Random.Range(0, 2)], spawnPoints[i].position, spawnPoints[i].rotation)
                .GetComponent<PlayerController>();

            player.entity = PlayerEntity.Entities[i];
            player.coloredMesh.material = attributes[i].material;
            playerTransforms.Add(player.transform);
        }

        CameraController.currentCamera.SetObjectToFollow(playerTransforms);

        DifficultySettings.SetNumberOfPlayers(playerTransforms.Count);
    }

    private void OnDrawGizmos()
    {
        if (spawnPoints != null)
        {
            for (int i = 0; i < spawnPoints.Count; i++)
            {
                Gizmos.color = attributes[i].color;
                Gizmos.DrawSphere(spawnPoints[i].position, .4f);
            }
        }

    }
}

[Serializable]
public class PlayerAttributes
{
    public Color color;
    public Material material;
}