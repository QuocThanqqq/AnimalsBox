using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimalsWave", menuName = "Animals Wave")]
public class AnimalsWave : ScriptableObject
{
    public List<Animals> Animal = new List<Animals>();
   
}
[System.Serializable]
public class Animals
{
    public GameObject animalPrefab;
    public int Quantity;
}