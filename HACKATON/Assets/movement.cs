using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingpower = 6f;
    private bool isfacingright = true;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
 
    void Start()
    {
        
    }

    
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump")&& IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingpower);
        }
        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        Flip();
    }
    private void FixedUpdate()
    {
       rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Flip()
    {
        if (isfacingright && horizontal < 0f || !isfacingright && horizontal > 0f)
        {
            isfacingright = !isfacingright;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
