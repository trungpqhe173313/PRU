using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
//1: tao random hanh tinh
//2: tang diem so khi ban chet ke thu
//3: kiem tra game ket thuc hay chua
public class GameController : MonoBehaviour
{
    public GameObject asteroid;

    public GameObject star;

    public float spawnTime;

    public int star_score;

    float m_spawnTime;

    int m_score;
    
    bool m_isGameover;

    UIManager m_ui;
    void Start()
    {
        m_ui = FindObjectOfType<UIManager>();
        m_spawnTime = 0;
        m_ui.SetScoreText("Score: "+ m_score);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isGameover) 
        {
            m_spawnTime = 0;
            m_ui.ShowGameoverPanel(true);
            return;
        }
        m_spawnTime -= Time.deltaTime;
        if(m_spawnTime <= 0)
        {
            SpawnAsteroid();
            SpawnStar();
            m_spawnTime = spawnTime;
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void AboutUsDirect()
    {
        SceneManager.LoadScene("About");
    }

    public void IntroductionDirect()
    {
        SceneManager.LoadScene("Instruction");
    }
    public void SpawnAsteroid()
    {
        int asteroidCount = Random.Range(1, 6);

        for (int i = 0; i < asteroidCount; i++)
        {
            float randXpos = Random.Range(-9f, 9f);
            Vector2 spawnPos = new Vector2(randXpos, 6); 

            if (asteroid)
            {
                GameObject newAsteroid = Instantiate(asteroid, spawnPos, Quaternion.identity);
                float randSpeed = Random.Range(2f, 5f);
                Asteroid asteroidScript = newAsteroid.GetComponent<Asteroid>();
                if (asteroidScript != null)
                {
                    asteroidScript.moveSpeed = randSpeed; 
                }
            }
        }
    }


    public void SpawnStar()
    {
        float randXpos = Random.Range(-9f, 9f);

        Vector2 spawnPos = new Vector2(randXpos, 6);

        if (star)
        {
            Instantiate(star, spawnPos, Quaternion.identity);
        }
    }
    public void SetScore(int value)
    {
        m_score = value;
    }
    public int GetScore()
    {
        return m_score;
    }
    public void ScoreIncrement()
    {
        if(m_isGameover)
        {
            return;
        }
        m_score+=star_score;
        m_ui.SetScoreText("Score: " + m_score);
    }

    public void SetGameoverState(bool state)
    {
        m_isGameover = state;
    }
    public bool IsGameover()
    {
         return m_isGameover;
    }

}
