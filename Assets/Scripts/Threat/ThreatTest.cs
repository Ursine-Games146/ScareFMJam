using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreatTest : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator anim;
    public GameObject Killbox;
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
