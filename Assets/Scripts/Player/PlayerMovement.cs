using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private int jumpNumber = 0;
    [SerializeField] private LayerMask terrainLayer;
    [SerializeField] private float distance = 1.0f;
    [SerializeField] public float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    private bool isFacingRight = true;

    private Animator anim;
    private Rigidbody2D rb;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("x_speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        anim.SetBool("Jumping", !IsGrounded());
        anim.SetBool("Grounded", IsGrounded());

        if (Input.GetButtonDown("Jump") && (IsGrounded() || jumpNumber < 2))
        {
            jumpNumber++;
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            Jump();
        }

        Flip();
    }

    public void Jump() => rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, terrainLayer);
        if (hit.collider != null)
        {
            jumpNumber = 0;
            anim.SetBool("Jumping", false);
            anim.SetBool("Grounded", true);
            return true;
        }

        return false;
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
