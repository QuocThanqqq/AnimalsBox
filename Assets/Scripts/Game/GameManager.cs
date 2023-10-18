using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public LevelData levelData;


    [SerializeField] private float timeLv1;
    [SerializeField] private float timeLv2;
    [SerializeField] private float timeLv3;

    public GameState State { get; set; }

    public LevelGame currentLevel = LevelGame.Level_1;

    
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
                break;
            case LevelGame.Level_2:
                currentLevel = LevelGame.Level_3;
                PlayLevel_3();
                break;
            case LevelGame.Level_3:
                currentLevel = LevelGame.EndGame;
                PlayLevel_EndGame();
                break;
        }
    }

    /// State Menu
    public void HandleMainMenu()
    {
        UIController.Instance.viewMainMenu.Show();
    }

    /// Level 1
    private async void PlayLevel_1()
    {
        UIController.Instance.viewInGame.Show();
        UIController.Instance.viewCountToPlay.Show();
        SoundManager.Instance.PlaySoundCountDown();
        await UniTask.Delay(2000);
        UIController.Instance.viewCountToPlay.Hide();
        UIController.Instance.viewInGame.isGameRunning = true;
        UIController.Instance.viewInGame.gameTime = timeLv1;
        SwitchToLevel(0);
        AnimalsSpawn.Instance.SpawnAnimalsWave(0);
    }

    /// Level 2
    private async void PlayLevel_2()
    {
        SoundManager.Instance.PlaySoundCountDown();
        UIController.Instance.viewCountToPlay.Show();
        await UniTask.Delay(2000);
        UIController.Instance.viewCountToPlay.Hide();
        UIController.Instance.viewInGame.isGameRunning = true;
        UIController.Instance.viewInGame.gameTime = timeLv2;
        SwitchToLevel(1);
        AnimalsSpawn.Instance.SpawnAnimalsWave(1);
    }

    /// Level 3
    private async void PlayLevel_3()
    {
        SoundManager.Instance.PlaySoundCountDown();
        UIController.Instance.viewCountToPlay.Show();
        await UniTask.Delay(2000);
        UIController.Instance.viewCountToPlay.Hide();
        UIController.Instance.viewInGame.isGameRunning = true;
        UIController.Instance.viewInGame.gameTime = timeLv3;
        SwitchToLevel(2);
        AnimalsSpawn.Instance.SpawnAnimalsWave(2);
    }
    /// End Game
    private void PlayLevel_EndGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    /// Change State Game
    public void ChangeButtonState()
    {
        UIController.Instance.viewMainMenu.Hide();
        currentLevel = LevelGame.Level_1;
        ChangeState(GameState.PlayGame);
    }

    /// Load Level Game    
    public void SwitchToLevel(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < levelData.levelNames.Length)
        {
            string levelName = levelData.levelNames[levelIndex];
            Debug.Log(levelName);
            UIController.Instance.viewInGame.levelText.text = levelName;
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
    Level_3,
    EndGame
}



