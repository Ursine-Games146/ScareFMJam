using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreatIdleState : ThreatState
{
    public ThreatIdleState(Threat threat, ThreatStateController stateController, ThreatData threatData, string animBoolName) : base(threat, stateController, threatData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (threat.transform.position.x - threat.player.position.x <= 5) ;
        {
            stateController.ChangeState(threat.ThreatChase);
        }
    }

    public override void RunChecks()
    {
        base.RunChecks();
    }

    
}
