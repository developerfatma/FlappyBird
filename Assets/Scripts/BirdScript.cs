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
    private bool oyunBitti = false;
    public AudioSource deathSoundSource; // <-- BURAYI PUBLIC YAPTIK!

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = 0;
        flapSound = GetComponent<AudioSource>(); // Kanat sesi için AudioSource bileşenini al

        // flapSound'ın atandığından emin ol
        if (flapSound == null)
        {
            Debug.LogError("Kanat sesi için bir AudioSource bileşeni bulunamıyor! Lütfen kuş objesine ekleyin.");
        }

        // deathSoundSource'un Inspector'dan atandığından emin ol
        if (deathSoundSource == null)
        {
            Debug.LogError("Ölüm sesi için AudioSource bileşeni atanmamış! Lütfen Inspector'dan atayın.");
        }
    }

    void Update()
    {
        if (!oyunBitti && Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jump;
            if (flapSound != null)
            {
                flapSound.Play();
            }
        }
        ScoreText.text = score.ToString();

        // Oyunun yeniden başlaması için 'R' tuşu kontrolü
        if (oyunBitti && Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Mevcut sahneyi yeniden yükle
            Time.timeScale = 1; // Oyunu tekrar başlat
            oyunBitti = false; // Oyun yeniden başladığında bu değişkeni sıfırla
        }

        // Oyundan çıkmak için 'Q' tuşu kontrolü
        if (oyunBitti && Input.GetKey(KeyCode.Q))
        {
            Application.Quit(); // Uygulamayı kapat
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
            if (!oyunBitti) // Ölüm sesini sadece bir kere çalmak için kontrol
            {
                Time.timeScale = 0;
                oyunBitti = true;

                // Ölüm sesini çal
                if (deathSoundSource != null)
                {
                    deathSoundSource.Play();
                }

                // Oyun bitti metinlerini göster
                if (gameOverText != null)
                {
                    gameOverText.gameObject.SetActive(true);
                }
                if (gameText != null) // gameText'i de kontrol et
                {
                    gameText.gameObject.SetActive(true);
                }
            }
        }
    }
}