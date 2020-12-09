using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbState : PlayerState
{
    public PlayerClimbState(Player player, CharacterStateController stateController, PlayerData playerData, string animBoolName) : base(player, stateController, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.Rb2d.gravityScale = 0;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Vector2 Y = player.Rb2d.velocity;
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            player.Anim.StopPlayback();
            Y.y = playerData.climbSpeed;
            player.Rb2d.velocity = Y;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            player.Anim.StopPlayback();
            Y.y = playerData.climbSpeed * -1;
            player.Rb2d.velocity = Y;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            player.Anim.StartPlayback();
            player.Rb2d.velocity = Vector2.zero;
        }

        if(!player.canClimb) //Add top and bottom of ladder
        {
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
