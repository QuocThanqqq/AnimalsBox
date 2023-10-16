using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class AnimalsData
{
    public GameObject animals;

}
public class AnimalsBehaviour : MonoBehaviour
{
    public AnimalsData animalsData;
    
    public void DataAnimals(AnimalsData data)
    {
        animalsData = data;
        
    }
}
