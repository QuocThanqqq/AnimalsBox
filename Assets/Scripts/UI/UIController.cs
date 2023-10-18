using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UIController : MonoBehaviour
{
    public static UIController Instance;
    
    private void Awake()
    {
        Instance = this;
    }

    public UIViewMainMenu viewMainMenu;
    public UIViewInGame viewInGame;
    public UIViewCountToPlay viewCountToPlay;

}
