using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls controls;
    float direction = 0;
    bool isFacingRight = true;

    public float speed;
    public float jumpForce;
    bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;
    

    public Rigidbody2D rb;
    public Animator animator;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.Movement.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };

        controls.Movement.Jump.performed += ctx => Jump();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);

        rb.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, rb.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(direction));

        if (isFacingRight && direction < 0 || !isFacingRight && direction > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
