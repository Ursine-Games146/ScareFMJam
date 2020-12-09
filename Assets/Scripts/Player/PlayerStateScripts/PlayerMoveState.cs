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
        Vector3 scale = player.transform.localScale;
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            scale = player.transform.localScale;
            scale.y = 1;
            X.x = playerData.moveSpeed;
            player.Rb2d.velocity = X;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            scale = player.transform.localScale;
            scale.y = -1;
            X.x = playerData.moveSpeed * -1;
            player.Rb2d.velocity = X;
        }
        else if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
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
