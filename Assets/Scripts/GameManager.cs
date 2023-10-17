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

    private LevelGame currentLevel = LevelGame.Level_1;

    void Start() => ChangeState(GameState.MainMenu);

  
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
                PlayLevel_1();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(gameState), gameState, null);
        }
        Debug.Log($"New state: {gameState}");
    }


    /// Change Level
    public void ChangeLevelToNext()
    {
        switch (currentLevel)
        {
            case LevelGame.Level_1:
                currentLevel = LevelGame.Level_2;
                PlayLevel_2();
                Debug.Log($"{currentLevel}");                  
                break;
            case LevelGame.Level_2:
                currentLevel = LevelGame.Level_3;
                PlayLevel_3();
                Debug.Log($"{currentLevel}");
                break;
        }
    }

    /// State Menu
    public void HandleMainMenu()
    {
        UIController.Instance.ViewMainMenu.Show();
    }
    
    /// Level 1
    private async void PlayLevel_1()
    {
        UIController.Instance.ViewInGame.Show();
        await UniTask.Delay(3000);
        UIController.Instance.ViewInGame.isGameRunning = true;
        SwitchToLevel(0);
        AnimalsSpawn.Instance.SpawnAnimalsWave(0);
    }

    /// Level 2
    private async void PlayLevel_2()
    {
        await UniTask.Delay(3000);
        UIController.Instance.ViewInGame.isGameRunning = true;
        SwitchToLevel(1);
        AnimalsSpawn.Instance.SpawnAnimalsWave(1);
    }

    /// Level 3
    private async void PlayLevel_3()
    {
        await UniTask.Delay(3000);
        UIController.Instance.ViewInGame.isGameRunning = true;
        SwitchToLevel(2);
        AnimalsSpawn.Instance.SpawnAnimalsWave(2);
    }

    /// Change State Game
    public void ChangeButtonState()
    {
        UIController.Instance.ViewMainMenu.Hide();
        ChangeState(GameState.PlayGame);
    }

    /// Load Level Game    
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

public enum LevelGame
{
    Level_1,
    Level_2,
    Level_3
}



