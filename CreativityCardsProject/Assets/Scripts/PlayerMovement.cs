using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpY;
    public bool hasJumped = false;

    private Rigidbody2D rb2d;

    private void Start()
    {
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
    }

}
