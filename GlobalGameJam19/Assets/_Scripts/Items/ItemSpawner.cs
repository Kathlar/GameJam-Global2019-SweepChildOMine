using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour, IDifficultyDependent
{
    public List<GameObject> itemPrefabs;
    public float minimalTimeBetweenSpawns = 2f, maximalTimeBetweenSpawns = 5f;
    protected float multiplier = 1;
    public float timeLengthOfLight = 3f;
    public Light light;
    protected bool lightOn;

    void Start()
    {
        if (light != null) Invoke("TurnOnLight", Mathf.Clamp(minimalTimeBetweenSpawns - timeLengthOfLight, 0, minimalTimeBetweenSpawns));
        Invoke("Spawn", minimalTimeBetweenSpawns);

        if (light != null)
        {
            InvokeRepeating("ChangeLightStatus", .66f, .66f);
            TurnOffLight();
        }
    }

    void Spawn()
    {
        TurnOffLight();
        Quaternion randomRotation = Quaternion.Euler(new Vector3(0, Random.Range(-180f, 180f), 0));
        GameObject obj = Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Count)], transform.position, randomRotation);

        float nextTime = Random.Range(minimalTimeBetweenSpawns / multiplier, maximalTimeBetweenSpawns / multiplier);
        if (light != null) Invoke("TurnOnLight", Mathf.Clamp(nextTime - timeLengthOfLight, 0, minimalTimeBetweenSpawns));
        Invoke("Spawn", nextTime);
    }

    void TurnOnLight()
    {
        lightOn = true;
        light.enabled = true;
    }

    void TurnOffLight()
    {
        lightOn = false;
        light.enabled = false;
    }

    void ChangeLightStatus()
    {
        if(lightOn)
            light.enabled = !light.enabled;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }

    public void SetDifficulty()
    {
        multiplier = DifficultySettings.Instance.difficultyLevel;
    }
}
