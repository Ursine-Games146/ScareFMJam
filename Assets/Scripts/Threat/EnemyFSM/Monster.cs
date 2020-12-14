using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private StateMachine _stateMachine;
    private bool _playerFound;

    public float searchTimer; //Might put these kind of settings in a different file. In a game state manager perhaps
    // Start is called before the first frame update
    private void Awake()
    {
        _stateMachine = new StateMachine();

        var roaming = new Roaming();
        var searchForPlayer = new SearchForPlayer();
        var chasePlayer = new ChasePlayer();
        var killPlayer = new KillPlayer();



        void At(IState from, IState to, Func<bool> condition) =>
            _stateMachine.AddTransition(from, to, condition); // At() is now a shortcut for _stateMachine.AddTransition(). At is short for Add Transition.

        Func<bool> RoamTimerEnded() => () => roaming.timer <= 0;
        Func<bool> PlayerNotFound() => () => searchTimer <= 0 && !_playerFound;

        Func<bool> PlayerFound() => () => _playerFound;
        //Func<bool> PlayerHid()
    }

    void Update() => _stateMachine.Tick();
    
    

}
