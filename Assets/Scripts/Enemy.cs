using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float moveSpeed;

    GameController m_gc;

    void Start()
    {
        moveSpeed = 3;
        m_gc = FindObjectOfType<GameController>();
    }

    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
   
        if(m_gc.GetScore() >= 10)
        {
            moveSpeed = 5;
        }

        if (m_gc.IsGameOver())
        {
            Destroy(gameObject);
        }      

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("DeathZone"))
        {
            m_gc.SetStateGameOver(true);
        }

        if (collision.CompareTag("Player"))
        {
            m_gc.SetStateGameOver(true);
        }
        
        if(collision.CompareTag("Projectile"))
        {
            m_gc.IncrementScore();
            Destroy(gameObject);
        }
    }
}
