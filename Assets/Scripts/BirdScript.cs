using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{
    public float jump;
    Rigidbody2D rb;
    public Text ScoreText;
    public float score;
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
    }

    void TriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag =="Scorer")
        {
            score++; 
        }
    }
}
