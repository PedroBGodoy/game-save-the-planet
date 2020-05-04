using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float gameSpeed = 1;

    public delegate void GameOverDelegate();
    public static event GameOverDelegate OnGameOver;
    public delegate void PlayDelegate();
    public static event PlayDelegate OnPlay;
    public delegate void MenuDelegate();
    public static event MenuDelegate OnMenu;
    public delegate void ResetDelegate();
    public static event ResetDelegate OnReset;

    public int score
    {
        get;
        private set;
    }

    private void Awake()
    {
        if (instance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        Menu();
    }

    private void Update()
    {
        if (Time.timeScale != gameSpeed)
        {
            Time.timeScale = gameSpeed;
        }
    }

    public void AddScore()
    {
        score++;
    }

    public void Menu()
    {
        OnMenu();
    }

    public void Reset()
    {
        score = 0;
        OnReset();
    }

    public void Play()
    {
        OnPlay();
    }

    public void GameOver()
    {
        OnGameOver();
    }

}
