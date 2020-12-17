using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SensorToolkit;

public class ThreatTest : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator anim;
    public Player player;
    public GameObject Killbox;
    public RaySensor2D rs2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(rb2d.velocity.x != 0)
        {
            anim.SetBool("idle", false);
            anim.SetBool("chase", true);
        }
        else if (rb2d.velocity.x == 0)
        {
            anim.SetBool("chase", false);
            anim.SetBool("idle", true);
        }

        if (player.isDead)
        {
            rs2d.enabled = false;
        }
    }

    public void DoAttack()
    {
        anim.SetTrigger("attack");
    }

    public void KillBox()
    {
        Killbox.SetActive(true);
    }

    public void StopAttack()
    {
        Killbox.SetActive(false);
    }
}
