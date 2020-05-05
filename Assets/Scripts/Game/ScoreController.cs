using UnityEngine;

public class ScoreController
{
    private int score = 0;
    private int highscore = 0;

    public void AddScore()
    {
        score++;
    }

    public int GetScore()
    {
        return score;
    }

    public void LoadScore()
    {
        highscore = PlayerPrefs.HasKey("highscore") ? PlayerPrefs.GetInt("highscore") : 0;
    }

    public void SubmitScore()
    {
        if (score <= highscore) return;

        PlayerPrefs.SetInt("hightscore", score);
    }

    public void ResetScore()
    {
        score = 0;
    }
}
