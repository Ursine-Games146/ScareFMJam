using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreatChaseState : ThreatState
{
    public ThreatChaseState(Threat threat, ThreatStateController stateController, ThreatData threatData, string animBoolName) : base(threat, stateController, threatData, animBoolName)
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

        Vector2 velocity = new Vector2((threat.transform.position.x - threat.player.position.x) * 1.0f, 0);
        threat.Rb2d.velocity = -velocity;
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
