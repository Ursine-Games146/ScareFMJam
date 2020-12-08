using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{

    public float speed;

    Rigidbody2D rb2d;
    GameObject player;

    void Start()
    {
        rb2d = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            rb2d.gravityScale = 0;

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.velocity = Vector2.up * speed;
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                rb2d.velocity = Vector2.down * speed;
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            rb2d.gravityScale = 1;
        }
    }
}
