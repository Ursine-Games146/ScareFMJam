using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected CharacterStateController stateController;
    protected PlayerIdleState playerIdle;
    protected PlayerMoveState playerMove;
    protected PlayerHideState playerHide;
    protected PlayerData playerData;
    protected Player player;

    protected float startTime;

    private string animBoolName;



    public PlayerState(Player player, CharacterStateController stateController, PlayerData playerData, string animBoolName)
    {
        this.player = player;
        this.stateController = stateController;
        this.playerData = playerData;
        this.animBoolName = animBoolName;

    }

    private void Awake()
    {

    }

    private void Start()
    {

    }

    public virtual void Enter()
    {
        RunChecks();
        player.Anim.SetBool(animBoolName, true);
        startTime = Time.time;
        Debug.Log(animBoolName);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        RunChecks();
    }

    public virtual void Exit()
    {
        player.Anim.SetBool(animBoolName, false);
    }

    public virtual void RunChecks()
    {

    }
}
