using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimalsSpawn : MonoBehaviour
{
    public static AnimalsSpawn Instance; 

    public AnimalsWave[] animalsWaves;
    public int currentWaveIndex;
    public List<GameObject> spawnedAnimalsList = new List<GameObject>();

    public void Awake()
    {
        Instance = this;
    }

    public void SpawnAnimalsWave(int waveIndex)
    {
        if (waveIndex < 0 || waveIndex >= animalsWaves.Length)
        {
            return;
        }

        AnimalsWave waveData = animalsWaves[waveIndex];
        foreach (Animals animalData in waveData.Animal)
        {
            for (int i = 0; i < animalData.Quantity; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-5f, -1f), 2, Random.Range(-5f, -1f));
                GameObject spawnedAnimal = Instantiate(animalData.animalPrefab, spawnPosition, Quaternion.identity);
                spawnedAnimalsList.Add(spawnedAnimal);
            }
        }
    }
}

