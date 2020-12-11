using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHideState : PlayerState
{
    public PlayerHideState(Player player, CharacterStateController stateController, PlayerData playerData, string animBoolName) : 
        base(player, stateController, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.isHiding = true;
        player.spriteRenderer.sortingLayerName = "Background";
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Input.GetKeyDown(KeyCode.Space) && player.canHide)
        {
            player.isHiding = false;
            player.spriteRenderer.sortingLayerName = "Player";
            stateController.ChangeState(player.PlayerIdle);
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
