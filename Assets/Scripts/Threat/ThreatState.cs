using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreatState
{
    protected ThreatStateController stateController;
    protected ThreatIdleState threatIdle;
    protected ThreatChaseState threatChase;
    protected ThreatAttackState threatAttack;
    protected ThreatData threatData;
    protected Threat threat;

    private string animBoolName;

    public ThreatState(Threat threat, ThreatStateController stateController, ThreatData threatData, string animBoolName)
    {
        this.threat = threat;
        this.stateController = stateController;
        this.threatData = threatData;
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
        threat.Anim.SetBool(animBoolName, true);
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
        threat.Anim.SetBool(animBoolName, false);
    }

    public virtual void RunChecks()
    {

    }
}
