using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIViewInGame : UIView
{
    [SerializeField] private RectTransform inGame;
    [SerializeField] private TextMeshProUGUI timeText;
    
    private float gameTime = 300;

    public RectTransform pnlWin;
    public bool isGameRunning = false;

    private void Update()
    {
        if (isGameRunning)
        {
            gameTime -= Time.deltaTime; // Tăng thời gian theo giây
            UpdateTimeText();
            
            if (gameTime <= 0)
            {
                isGameRunning = false;
                Debug.Log("Over Time");
            }
        }
    }

    protected override void Start()
    {
        base.Start();
    }

    public override void Show(object data = null, Action<bool> isDone = null)
    {
        base.Show(data, isDone);
    }

    public override void Hide(Action<bool> isDone = null)
    {
        base.Hide(isDone);
    }
    
    private void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(gameTime / 60);
        int seconds = Mathf.FloorToInt(gameTime % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
