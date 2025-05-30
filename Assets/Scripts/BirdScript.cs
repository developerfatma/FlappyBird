using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour
{
    public float jump;
    Rigidbody2D rb;
    public Text ScoreText;
    public float score;
    public Text gameOverText;
    public Text gameText;
    private AudioSource flapSound;
    private bool gameEnd = false;
    public AudioSource deathSoundSource; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = 0;
        flapSound = GetComponent<AudioSource>(); 

       
        if (flapSound == null)
        {
            Debug.LogError("Cannot find an AudioSource component for wing sound! Please add it to the bird object.");
        }

      
        if (deathSoundSource == null)
        {
            Debug.LogError("Cannot find an AudioSource component for wing sound! Please add it to the bird object.");
        }
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
        if (collision.gameObject.tag == "pipe" || collision.gameObject.CompareTag("Ground"))
        {
            if (!gameEnd) 
            {
                Time.timeScale = 0;
                gameEnd = true;

               
                if (deathSoundSource != null)
                {
                    deathSoundSource.Play();
                }

                
                if (gameOverText != null)
                {
                    gameOverText.gameObject.SetActive(true);
                }
                if (gameText != null) 
                {
                    gameText.gameObject.SetActive(true);
                }
            }
        }
    }
}