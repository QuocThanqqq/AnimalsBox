using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
   [SerializeField] private List<GameObject> AnimalsPick = new List<GameObject>();

   [SerializeField] private List<GameObject> Animals;


    private void Start()
    {
        Animals = AnimalsSpawn.Instance.spawnedAnimalsList;
    }

    private void Update()
    {
   
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.collider.gameObject;

                if (hitObject.CompareTag("Animals"))
                {
                    AnimalsPick.Add(hitObject);
                    hitObject.SetActive(false);
                   
                }            
            }

            /// Check Point
            if (CheckForConsecutiveAnimals(AnimalsPick))
            {
                Debug.Log("YOY NICE");

                for (int i = 0; i < 3; i++)
                {
                    AnimalsPick.RemoveAt(AnimalsPick.Count - 1);
                }
            }

            /// Check Lose
            if (AnimalsPick.Count >= 6)
            {
                Debug.Log("YOU LOSE");

            }

            if (UIController.Instance.ViewInGame.isGameRunning == true)
            {
                CheckWinCondition();
            }        
        }

    }


    /// Check Animals
    private bool CheckForConsecutiveAnimals(List<GameObject> objects)
    {
        int consecutiveCount = 0;
        string previousName = "";

        foreach (var obj in objects)
        {
            if (obj.CompareTag("Animals") && obj.name == previousName)
            {
                consecutiveCount++;
                if (consecutiveCount == 3)
                {
                    return true;
                }
            }
            else
            {
                consecutiveCount = 1;
            }

            previousName = obj.name;
        }

        return false;
    }

     /// Check Win
    private bool CheckWinCondition()
    {
        foreach (GameObject animal in Animals)
        {
            if (animal.activeSelf)
            {
                return false;
            }
        }
        Debug.Log("YOU WINNNER!");
        UIController.Instance.ViewInGame.pnlWin.gameObject.SetActive(true);
        UIController.Instance.ViewInGame.isGameRunning = false;
        return true;       
    }
}


