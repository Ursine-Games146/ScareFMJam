using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public Rigidbody2D Rb2d;

    public PlayerMoveState(Player player, CharacterStateController stateController, PlayerData playerData, string animBoolName) : 
        base(player, stateController, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Rb2d = player.Rb2d;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();


        Vector2 X = player.Rb2d.velocity;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))        //Move Right
        {
            playerData.currentStamina += 0.1f * Time.deltaTime;
            player.spriteRenderer.flipX = false;
            player.Anim.speed = 1.0f;
            X.x = playerData.moveSpeed;
            player.Rb2d.velocity = X;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))        //Move Left
        {
            playerData.currentStamina += 0.1f * Time.deltaTime;
            player.spriteRenderer.flipX = true;
            player.Anim.speed = 1.0f;
            X.x = playerData.moveSpeed * -1;
            player.Rb2d.velocity = X;
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            stateController.ChangeState(player.PlayerIdle);         //No Input
        }


        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && Input.GetKey(KeyCode.LeftShift) && playerData.currentStamina > 0)
        {       //Sprinting Right
            playerData.currentStamina -= 1.0f * Time.deltaTime;
            player.staminaBar.fillAmount = playerData.currentStamina / playerData.maxStamina;
            player.spriteRenderer.flipX = false;
            player.Anim.speed = 1.5f;
            X.x = playerData.runSpeed;
            player.Rb2d.velocity = X;
        }
        else if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && Input.GetKey(KeyCode.LeftShift) && playerData.currentStamina > 0)
        {       //Sprinting Left
            playerData.currentStamina -= 1.0f * Time.deltaTime;
            player.staminaBar.fillAmount = playerData.currentStamina / playerData.maxStamina;
            player.spriteRenderer.flipX = true;
            player.Anim.speed = 1.5f;
            X.x = playerData.runSpeed * -1;
            player.Rb2d.velocity = X;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || playerData.currentStamina <= 0)   //Stop Sprinting
        {
            X.x = 0;
            player.Rb2d.velocity = X;
        }
        

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void RunChecks()
    {
        base.RunChecks();
    }
}
