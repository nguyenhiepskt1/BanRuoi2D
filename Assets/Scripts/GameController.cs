using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject enemy;
    float spawnTime;

    float m_spawnTime;
    int m_score;
    bool m_isGameOver;

    UIManager m_u;

    void Start()
    {
        spawnTime = 2;
        m_spawnTime = 0;
        m_score = 0;
        m_u = FindObjectOfType<UIManager>();
        m_u.SetTextScore("Score: " + m_score);
    }

    void Update()
    {
        m_spawnTime -= Time.deltaTime;

        if(m_isGameOver)
        {
            spawnTime = 0;
            m_u.showPanelGameOver(true);
            Time.timeScale = 0;
            return;
        }

        if(m_spawnTime <= 0)
        {
            spawnEnemy();
            m_spawnTime = spawnTime;
        }

        if(m_score >= 10)
        {
            spawnTime = 1;
        }
    }

    public void spawnEnemy()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-6.47f, 6.47f), 4.5f);

        if(enemy)
        {
            Instantiate(enemy, spawnPos, Quaternion.identity);
        }
    }

    public void PlayAgain()
    {
        m_score = 0;
        m_u.SetTextScore("Score: " + m_score);
        m_u.showPanelGameOver(false);
        m_isGameOver = false;
        spawnTime = 2;
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public int GetScore()
    {
        return m_score;
    }

    public void SetScore(int value)
    {
        m_score = value;
    }

    public void IncrementScore()
    {
        m_score++;
        m_u.SetTextScore("Score: " + m_score);
    }

    public bool IsGameOver()
    {
        return m_isGameOver;
    }

    public void SetStateGameOver(bool state)
    {
        m_isGameOver = state;
    }
}
