using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LeapInternal;
using UnityEngine.UI;

public class scr : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI percentageText;
    public TextMeshProUGUI percentageCaptionText;
    public TextMeshProUGUI sloganText;
    public TextMeshProUGUI timeText;
    public Button nextButton;

    int currentScore = 7;
    int maxScore = 10;
    float time = 70;
    void Start()
    {
        DisplayScore();
        DisplayPercentage();
        DisplaySlogan();
        DisplayTime(time);
    }

    public void UpdateScore(int score)
    {
        currentScore = score;
        DisplayScore();
        DisplayPercentage();
        DisplaySlogan();
        UpdateTime(time);
    }

    public void DisplayScore()
    {
        scoreText.text = currentScore.ToString() + "/" + maxScore.ToString();
    }

    public void DisplayPercentage()
    {
        float percentage = (float)currentScore / maxScore * 100;
        percentageText.text = percentage.ToString() + "%";

        if (percentage >= 80)
        {
            percentageCaptionText.text = "Sempurna!";
        }
        else if (percentage >= 50)
        {
            percentageCaptionText.text = "Bagus!";
        }
        else
        {
            percentageCaptionText.text = "Belajar Lagi!";
        }
    }

    public void DisplaySlogan()
    {
        if (currentScore == maxScore)
        {
            sloganText.text = "Kamu Keren Sekali!";
        }
        else if (currentScore >= maxScore / 2)
        {
            sloganText.text = "Kamu Hebat!";
        }
        else
        {
            sloganText.text = "Yuk Belajar Lagi!";
        }
    }

    public void DisplayTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void UpdateTime(float time)
    {
        this.time = time;
        DisplayTime(time);
    }

    public void OnNextButtonClick()
    {
        // Handle the next button click event
        // For example, load the next scene or reset the game
        Debug.Log("Next button clicked!");
        // LoadNextScene();
    }
}
