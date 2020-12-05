using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed, jumpForce, groundRadius;
    public float fallMultiple = 2.5f;
    public float lowJump = 2f;

    [SerializeField] private bool isGrounded;

    Rigidbody2D rb2d;

    public Transform detectGround;
    public LayerMask whatIsGround;

    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        CheckMovement();
        CheckJump();

        Collider2D collider = Physics2D.OverlapCircle(detectGround.position, groundRadius, whatIsGround);
        if(collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if(rb2d.gravityScale == 1 && !isGrounded)
        {
            if (rb2d.velocity.y < 0)
            {
                rb2d.velocity += Vector2.up * Physics2D.gravity * (fallMultiple - 1) * Time.deltaTime;
            }
        }
    }

    void FixedUpdate()
    {
        
    }

    void CheckMovement()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.velocity = new Vector2(-1.0f * speed, rb2d.velocity.y);
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.velocity = new Vector2(1.0f * speed, rb2d.velocity.y);
        }
        else if(rb2d.velocity.y == 0)
        {
            rb2d.velocity = Vector2.zero;
        }
        
    }

    void CheckJump()
    {
        if(Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(detectGround.position, groundRadius);
    }
}
