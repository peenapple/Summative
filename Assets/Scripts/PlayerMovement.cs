using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal; // horizontal input
    private float speed = 6.5f;
    private float jumpingPower = 13f;
    private bool isFacingRight = true; // which way the player faces
    private bool finish = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        if (finish == false)
        {
            horizontal = Input.GetAxisRaw("Horizontal"); // returns -1, 0 or 1 depending on direction of movement

            // jump if grounded
            if (Input.GetKey(KeyCode.W) && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }

            // jump even higher if button is released and the player is still moving upwards
            if (Input.GetKeyUp(KeyCode.W) && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }

            Flip();
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if you collide with end flag
        if (collision.gameObject.CompareTag("Finish"))
        {
            finish = true;
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    // Update is called at fixed time intervals
    private void FixedUpdate()
    {
        if (finish == false)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); // set velocity
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private bool IsGrounded() // check if we are grounded
    {
        // creates invisible circle right at the player's feet that can collide with the ground layer
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        // flip the player when necessary to face a different direction
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f; // multiply the x by -1
            transform.localScale = localScale;
        }
    }
}
