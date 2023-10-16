using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance;
    
    private void Awake()
    {
        Instance = this;
    }

    public UIViewMainMenu ViewMainMenu;
    public UIViewInGame ViewInGame;
}
