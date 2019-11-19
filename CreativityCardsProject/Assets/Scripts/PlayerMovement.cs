using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpY;
    public bool hasJumped = false;

    private Rigidbody2D rb2d;

    [SerializeField] private int currentScore;
    [SerializeField] private Text scoreText;
    [SerializeField] private int commonFishReward;
    [SerializeField] private int rareFishReward;
    [SerializeField] private int veryRareFishReward;

    private void Start()
    {
        currentScore = 0;
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector2 jump = new Vector2(0, jumpY);

        transform.position = new Vector2(transform.position.x + moveHorizontal, transform.position.y);

        if (Input.GetKeyDown(KeyCode.Space) && (!hasJumped))
        {
            hasJumped = true;
            rb2d.AddForce(jump, ForceMode2D.Impulse);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Floor"))
        {
            hasJumped = false;
        }
        else if (other.gameObject.layer == 8)
        {
            //common fish
            currentScore += commonFishReward;
            UpdateScore();
        }
        else if (other.gameObject.layer == 9)
        {
            //rare fish
            currentScore += rareFishReward;
            UpdateScore();
        }
        else if (other.gameObject.layer == 10)
        {
            //very rare fish
            currentScore += veryRareFishReward;
            UpdateScore();
        }

    }

    private void UpdateScore()
    {
        scoreText.text = "Score = " + currentScore.ToString();
    }

}
