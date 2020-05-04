using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public TextMeshProUGUI scoreTxt;
    public Button playBtn;
    public Button menuBtn;
    public Button playAgainBtn;

    private void OnEnable()
    {
        GameManager.OnGameOver += OnGameOver;
        GameManager.OnMenu += OnMenu;
        GameManager.OnPlay += OnPlay;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= OnGameOver;
        GameManager.OnMenu -= OnMenu;
        GameManager.OnPlay -= OnPlay;
    }

    private void Update()
    {
        if (scoreTxt && GameManager.instance)
            scoreTxt.text = GameManager.instance.score.ToString();
    }

    public void Play()
    {
        GameManager.instance.Play();
    }

    public void PlayAgain()
    {
        GameManager.instance.Reset();
        GameManager.instance.Play();
    }

    public void Menu()
    {
        GameManager.instance.Menu();
        GameManager.instance.Reset();
    }

    public void OnPlay()
    {
        playBtn.gameObject.SetActive(false);
        menuBtn.gameObject.SetActive(false);
        playAgainBtn.gameObject.SetActive(false);
    }

    public void OnMenu()
    {
        menuBtn.gameObject.SetActive(false);
        playAgainBtn.gameObject.SetActive(false);
        playBtn.gameObject.SetActive(true);
    }

    public void OnGameOver()
    {
        menuBtn.gameObject.SetActive(true);
        playAgainBtn.gameObject.SetActive(true);
    }

}
