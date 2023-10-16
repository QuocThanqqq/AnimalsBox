using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    public LevelData levelData;

    public GameState State { get; set; }
    
    
    void Start() => ChangeState(GameState.MainMenu);
    
    void Update()
    {
        if (Input.anyKeyDown) 
        {
            ChangeButtonState();
        }
    }
    // Change State
    public void ChangeState(GameState gameState)
    {
        State = gameState;
        switch (gameState)
        {
            case GameState.MainMenu:
                HandleMainMenu();
                break;
            case GameState.PlayGame:
                HandlePlayLevel1();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(gameState), gameState, null);
        }
        Debug.Log($"New state: {gameState}");
    }

    
    public void HandleMainMenu()
    {
        UIController.Instance.ViewMainMenu.Show();
    }
    
    private async void HandlePlayLevel1()
    {
        UIController.Instance.ViewInGame.Show();
        await UniTask.Delay(3000);
        UIController.Instance.ViewInGame.isGameRunning = true;
        SwitchToLevel(0);
        AnimalsSpawn.Instance.SpawnAnimalsWave(0);
    }
    
    public void ChangeButtonState()
    {
        UIController.Instance.ViewMainMenu.Hide();
        ChangeState(GameState.PlayGame);
    }
    
    public void SwitchToLevel(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < levelData.levelNames.Length)
        {
            string levelName = levelData.levelNames[levelIndex];
            Debug.Log(levelName);
        }
    }
}
public enum GameState
{
    MainMenu,
    PlayGame
}



