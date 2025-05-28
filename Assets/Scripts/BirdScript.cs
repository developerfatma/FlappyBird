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
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jump;
        }
        ScoreText.text = score.ToString();

        // Oyunun yeniden başlaması için 'R' tuşu kontrolü
        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Mevcut sahneyi yeniden yükle
            Time.timeScale = 1; // Oyunu tekrar başlat
        }

        // Oyundan çıkmak için 'Q' tuşu kontrolü
        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit(); // Uygulamayı kapat
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag =="Scorer")
        {
            score++; 
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "pipe")
        {
            Time.timeScale = 0;
            if (gameOverText != null)
            {
                gameOverText.gameObject.SetActive(true); // Oyun bitti metnini göster
                gameText.gameObject.SetActive(true); // Oyun bitti metnini göster
            }
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Time.timeScale = 0;
            if (gameOverText != null)
            {
                gameOverText.gameObject.SetActive(true); // Oyun bitti metnini göster
                gameText.gameObject.SetActive(true); // Oyun bitti metnini göster
            }
        }
    }
}
