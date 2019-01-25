using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DifficultySettings : ASingleton<DifficultySettings>
{
    public enum DifficultyLevel
    {
        Easy = 1, Medium = 2, Hard = 4
    }
    public DifficultyLevel level;

    protected List<IDifficultyDependent> dependents = new List<IDifficultyDependent>();

    [HideInInspector] public float difficultyLevel;
    protected float numberOfPlayers;

    void Start()
    {
        foreach (IDifficultyDependent dependent in FindObjectsOfType<MonoBehaviour>().OfType<IDifficultyDependent>())
        {
            dependents.Add(dependent);
        }
    }

    public static void SetNumberOfPlayers(int numberOfPlayers)
    {
        Instance.numberOfPlayers = (float) numberOfPlayers;
        CountDifficulty();
    }

    public static void SetDifficulty(DifficultyLevel level)
    {
        Instance.level = level;
    }

    public static void CountDifficulty()
    {
        Instance.difficultyLevel = .2f * ((float) Instance.level + Instance.numberOfPlayers);

        foreach (IDifficultyDependent dependent in Instance.dependents)
        {
            dependent.SetDifficulty();
        }
    }
}
