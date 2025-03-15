using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public ParticleSystem Dust;
    private float horizontal;
    private float speed = 6f;
    private float jumpingpower = 8f;
    private bool isfacingright = true;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator anim;
    AudioManager audioManager;
 
    void Start()
    {

    }
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        
        anim.SetFloat("speed", Mathf.Abs(horizontal));
        audioManager.PlaySFX(audioManager.steps);
        if (Input.GetButtonDown("Jump")&& IsGrounded())
        {
            anim.SetBool("isGrounded", false);
            rb.velocity = new Vector2(rb.velocity.x, jumpingpower);
            CreateDust();
            audioManager.PlaySFX(audioManager.floor);
            Invoke("skok", 1.5f);
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            //anim.SetBool("isGrounded", false);
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
            CreateDust();
        }
    }
    private void skok()
    {
        anim.SetBool("isGrounded", true);
    }
    void CreateDust()
    {
        Dust.Play();
    }
}
