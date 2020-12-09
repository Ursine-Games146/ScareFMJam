﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{


    public CharacterStateController StateController { get; private set; }


    public PlayerIdleState PlayerIdle { get; private set; }
    public PlayerMoveState PlayerMove { get; private set; }
    public PlayerHideState PlayerHide { get; private set; }
    public PlayerClimbState PlayerClimb { get; private set; }


    public Animator Anim { get; private set; }

    public Image staminaBar;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D Rb2d;

    public int FacingDirection { get; set; }
    public bool canHide { get; set; }
    public bool isHiding { get; set; }
    public bool canClimb { get; set; }

    [SerializeField] private PlayerData playerData;


    private void Awake()
    {
        StateController = new CharacterStateController();

        PlayerIdle = new PlayerIdleState(this, StateController, playerData, "idle");
        PlayerMove = new PlayerMoveState(this, StateController, playerData, "moving");
        PlayerHide = new PlayerHideState(this, StateController, playerData, "hiding");
        PlayerClimb = new PlayerClimbState(this, StateController, playerData, "climbing");
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        Rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        playerData.currentStamina = playerData.maxStamina;
        isHiding = false;
        canHide = false;
        canClimb = false;
        FacingDirection = 1;

        StateController.Initialize(PlayerIdle);
    }

    private void Update()
    {
        StateController.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateController.CurrentState.PhysicsUpdate();
    }


    //Functions

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Hideable"))
        {
            canHide = true;
        }
        else if(collision.CompareTag("Climbable"))
        {
            canClimb = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Hideable"))
        {
            canHide = false;
        }
        else if (collision.CompareTag("Climbable"))
        {
            canClimb = false;
            Rb2d.gravityScale = 1;
        }
    }
}
