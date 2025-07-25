using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private float jump;    
    [SerializeField] private float score; 
    [SerializeField] private bool gameEnd = false;
    [SerializeField] private Text ScoreText;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Text gameText;
    [SerializeField] private AudioSource flapSound;
    
    [SerializeField] private AudioSource deathSoundSource; 

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        if (!gameEnd && Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jump;
            if (flapSound != null)
            {
                flapSound.Play();
            }
        }
        ScoreText.text = score.ToString();

        
        if (gameEnd && Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
            Time.timeScale = 1; 
            gameEnd = false;
        }

       
        if (gameEnd && Input.GetKey(KeyCode.Q))
        {
            Application.Quit(); 
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Scorer")
        {
            score++;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pipe") || collision.gameObject.CompareTag("Ground"))
        {
            if (!gameEnd) 
            {
                Time.timeScale = 0;
                gameEnd = true;

                if (deathSoundSource != null || gameOverText != null)
                {
                    deathSoundSource.Play();
                    gameOverText.gameObject.SetActive(true);
                    gameText.gameObject.SetActive(true);
                }
            }
        }
    }
}