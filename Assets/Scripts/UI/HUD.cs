using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public TextMeshProUGUI scoreTxt;
    public Button playBtn;
    public Button menuBtn;
    public Button playAgainBtn;

    private void Update()
    {
        if (scoreTxt && OldGameManager.instance)
            scoreTxt.text = OldGameManager.instance.score.ToString();
    }

    public void Play()
    {
        playBtn.gameObject.SetActive(false);
        menuBtn.gameObject.SetActive(false);
        playAgainBtn.gameObject.SetActive(false);
    }

    public void PlayAgain()
    {
        OldGameManager.instance.Reset();
        OldGameManager.instance.Play();
    }

    public void Menu()
    {
        menuBtn.gameObject.SetActive(false);
        playAgainBtn.gameObject.SetActive(false);
        playBtn.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        menuBtn.gameObject.SetActive(true);
        playAgainBtn.gameObject.SetActive(true);
    }

}
