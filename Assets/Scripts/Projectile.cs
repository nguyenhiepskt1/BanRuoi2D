using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float moveSpeed;
    float timeToDestroy;

    Rigidbody2D m_rb;

    GameController m_gc;

    void Start()
    {
        moveSpeed = 10;
        timeToDestroy = 3;
        Destroy(gameObject, timeToDestroy);
        m_gc = FindObjectOfType<GameController>();
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        m_rb.velocity = Vector2.up * moveSpeed;

        if (m_gc.IsGameOver())
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SceneTopLimit"))
        {
            Destroy(gameObject);
        }
    }
}
