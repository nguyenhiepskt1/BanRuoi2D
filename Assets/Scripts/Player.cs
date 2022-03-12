using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float moveSpeed;
    float xDirection;
    float yDirection;
    GameController m_gc;

    public GameObject projectile;
    public Transform shootingposition;

    public AudioSource audio;
    public AudioClip shootSound;
    
    void Start()
    {
        moveSpeed = 9;
        m_gc = FindObjectOfType<GameController>();
    }
    
    void Update()
    {
        xDirection = Input.GetAxisRaw("Horizontal");
        yDirection = Input.GetAxisRaw("Vertical");

        float moveStep = moveSpeed * xDirection * Time.deltaTime;
        float y_moveStep = moveSpeed * yDirection * Time.deltaTime;

        if((transform.position.x < -6.75 && xDirection < 0) || (transform.position.x > 6.69 && xDirection > 0))
        {
            return;
        }
        if((transform.position.y < -0.17 && yDirection < 0) || (transform.position.y > 7.67 && yDirection > 0))
        {
            return;
        }

        transform.position += new Vector3(moveStep, 0, 0);
        transform.position += new Vector3(0, y_moveStep, 0);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        if(m_gc.GetScore() >= 10)
        {
            moveSpeed = 14;
        }

        if(m_gc.IsGameOver())
        {
            audio.Pause();
        }

        else
        {
            audio.UnPause();
        }
    }

    public void Shoot()
    {
        if(projectile && shootingposition)
        {
            Instantiate(projectile, shootingposition.position, Quaternion.identity);

            if(audio && shootSound)
            {
                audio.PlayOneShot(shootSound);
            }
        }
    }
}
