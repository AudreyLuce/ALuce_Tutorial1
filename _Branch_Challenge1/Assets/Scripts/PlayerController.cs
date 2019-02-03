using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text scoreText;
    public Text winText;
    public Text livesText;
    public Text loseText;

    private Rigidbody rb;
    private int count;
    private int score;
    private int totalScore;
    private int lives;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        totalScore = 0;
        lives = 3;
        winText.text = "";
        loseText.text = "";
        SetScoreText();
        SetCountText();
        SetLivesText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 1;
            totalScore++;
            SetCountText();
            SetScoreText();

            if (totalScore == 12)
            {
                transform.position = new Vector3(13.0f, transform.position.y, 7.75f);
            }
        }
        else if (other.gameObject.CompareTag("Red Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            lives = lives - 1;
            SetCountText();
            SetLivesText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        if(score >= 20)
        {
            this.gameObject.SetActive(false);
            winText.text = "You Win!";
        }
    }

    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
        if(lives <= 0)
        {
            this.gameObject.SetActive(false);
            loseText.text = "You Lose!";
        }
    }
}
