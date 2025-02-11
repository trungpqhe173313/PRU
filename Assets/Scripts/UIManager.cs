using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{

    public Text scoreText;

    public Text endScore;

    public GameObject gameoverPanel;

    private string score; 
    public void SetScoreText(string txt)
    {
        if(scoreText)
        {
            score = txt;
            scoreText.text = txt;
        }
    }


    public void ShowGameoverPanel(bool isShow)
    {
        if(gameoverPanel)
        {
            gameoverPanel.SetActive(isShow);
            endScore.text = score;
        }
    }
}
