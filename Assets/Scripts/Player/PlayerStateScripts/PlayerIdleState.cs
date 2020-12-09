﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player, CharacterStateController stateController, PlayerData playerData, string animBoolName) : 
        base(player, stateController, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.Rb2d.velocity = Vector2.zero;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        playerData.currentStamina += 0.5f * Time.deltaTime;
        player.staminaBar.fillAmount = playerData.currentStamina / playerData.maxStamina;
        if(playerData.currentStamina > playerData.maxStamina)
        {
            playerData.currentStamina = playerData.maxStamina;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            stateController.ChangeState(player.PlayerMove);
        }

        if(Input.GetKeyDown(KeyCode.Space) && player.canHide)
        {
            stateController.ChangeState(player.PlayerHide);
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
