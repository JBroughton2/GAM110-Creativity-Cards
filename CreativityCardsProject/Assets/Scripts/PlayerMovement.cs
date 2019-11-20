using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpY;
    public bool hasJumped = false;
    private bool facingRight;
    public Animator animator;

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        facingRight = true;
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector2 jump = new Vector2(0, jumpY);

        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));

        transform.position = new Vector2(transform.position.x + moveHorizontal, transform.position.y);

        if (Input.GetKeyDown(KeyCode.Space) && (!hasJumped))
        {
            hasJumped = true;
            rb2d.AddForce(jump, ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            hasJumped = false;
        }
        animator.SetBool("IsJumping", false);
    }

    private void Flip(float moveHorizontal)   //don't uncomment this unless you want to flip and fix the gun sprite as well
    {
        if (moveHorizontal > 0 && !facingRight || moveHorizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }

}
