using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    Rigidbody2D rb2d;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        CheckMovement();
    }

    void FixedUpdate()
    {
        
    }

    void CheckMovement()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.velocity = Vector2.left * speed;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.velocity = Vector2.right * speed;
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
