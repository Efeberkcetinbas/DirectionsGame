using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public GameData gameData;


    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnSuccess,OnStopTime);
        EventManager.AddHandler(GameEvent.OnGameOver,OnStopTime);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnSuccess,OnStopTime);
        EventManager.RemoveHandler(GameEvent.OnGameOver,OnStopTime);
    }

    void OnStopTime()
    {
        gameData.timerIsRunning=false;
    }
    

    void Update()
    {
        if (gameData.timerIsRunning)
        {
            gameData.RemainingTime += Time.deltaTime;
            DisplayTime(gameData.RemainingTime);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); //60tan sonra dakikaya 1 ekliyor.

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds); //dakika saniye cinsinden gösteriyor.
    }
}
