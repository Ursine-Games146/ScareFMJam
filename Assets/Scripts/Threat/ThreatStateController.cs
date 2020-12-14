using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreatStateController
{
    public ThreatState CurrentState { get; private set; }


    public void Initialize(ThreatState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(ThreatState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
