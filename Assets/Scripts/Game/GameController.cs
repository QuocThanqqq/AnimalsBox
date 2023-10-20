using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
   [SerializeField] private List<GameObject> animalsPick = new List<GameObject>();

   [SerializeField] private List<Sprite> animalSprites = new List<Sprite>();
   
   [SerializeField] private List<GameObject> animals;

    private void Start()
    {
        animals = AnimalsSpawn.Instance.spawnedAnimalsList;
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            SoundManager.Instance.PlaySoundClick();

            if (Physics.Raycast(ray, out hit))
            {

                GameObject hitObject = hit.collider.gameObject;
                if (hitObject.CompareTag("Animals"))
                {
                    animalsPick.Add(hitObject);
                    hitObject.SetActive(false);

                    // Find Sprite
                    Transform spriteObject = hitObject.transform.Find("Sprite");
                    if (spriteObject != null)
                    {
                        SpriteRenderer spriteRenderer = spriteObject.GetComponent<SpriteRenderer>();
                        if (spriteRenderer != null)
                        {
                            animalSprites.Add(spriteRenderer.sprite);
                        }
                    }
                }

            }

            ///Check Point
            if (CheckForConsecutiveAnimals(animalsPick))
            {
                for (int i = 0; i < 3; i++)
                {
                    if (animalsPick.Count > 0)
                    {
                        SoundManager.Instance.PlayMatchPoint();
                        GameObject removedAnimal = animalsPick[animalsPick.Count - 1];
                        animalsPick.RemoveAt(animalsPick.Count - 1);
                        RemoveSprite(removedAnimal);
                    }
                }
            }

            ///Check Lose
            if (animalsPick.Count >= 6 || UIController.Instance.viewInGame.gameTime <= 0)
            {
                UIController.Instance.viewInGame.pnlLose.gameObject.SetActive(true);
                UIController.Instance.viewInGame.isGameRunning = false;
                SoundManager.Instance.PlaySoundLose();
                foreach (GameObject animal in animals)
                {
                    Destroy(animal);
                }
                animals.Clear();
                animalsPick.Clear();
                animalSprites.Clear();
            }

            ///Win
            if (UIController.Instance.viewInGame.isGameRunning == true)
            {
                CheckWinCondition();
            }        
        }

        SpritesToImages();
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
        foreach (GameObject animal in animals)
        {
            if (animal.activeSelf)
            {
                return false;
            }
        }

        foreach (GameObject animal in animals)
        {
            Destroy(animal);
        }
        animals.Clear();

        UIController.Instance.viewInGame.pnlWin.gameObject.SetActive(true);
        UIController.Instance.viewInGame.isGameRunning = false;
        SoundManager.Instance.PlaySoundWin();
        return true;       
    }
    // RemoveSprite
     private void RemoveSprite(GameObject animal)
     {
         Transform spriteObject = animal.transform.Find("Sprite");
         if (spriteObject != null)
         {
             SpriteRenderer spriteRenderer = spriteObject.GetComponent<SpriteRenderer>();
             if (spriteRenderer != null)
             {
                 animalSprites.Remove(spriteRenderer.sprite);
             }
         }
     }
     // SpritesToImages
     private void SpritesToImages()
     {
         for (int i = 0; i < UIController.Instance.viewInGame.imageAnimals.Count; i++)
         {
            
             if (i < animalSprites.Count)
             {
                 UIController.Instance.viewInGame.imageAnimals[i].sprite = animalSprites[i];
             }
             else
             {

                 UIController.Instance.viewInGame.imageAnimals[i].sprite = UIController.Instance.viewInGame.defaultImage;
             }
         }
     }

}


