using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class StateMachine : MonoBehaviour
{
    private IState _currentState;
    private Dictionary<Type, List<Transition>> _transitions = new Dictionary<Type, List<Transition>>();
    private List<Transition> _currentTransitions = new List<Transition>();
    private List<Transition> _anyTransitions = new List<Transition>();
    
    private static List<Transition> EmptyTransitions = new List<Transition>(capacity: 0);

    public void Start()
    {
        _currentState = new Roaming();
    }

    public void Tick()
    {
        var transition = GetTransition();
        if(transition != null)
            SetState(transition.To); //checks for valid transitions. If it finds one that is set to true, it switches to the 'To' state set in the Transition object.
        _currentState?.Tick();
    }

    public void SetState(IState state)
    {
        if (state == _currentState)
            return;
        _currentState?.OnExit();
        _currentState = state;
        _currentState.OnEnter();

        _transitions.TryGetValue(_currentState.GetType(), out _currentTransitions); // try to get the list of transitions for the newly set state and put them in _currentTransitions.
        if (_currentTransitions == null)
            _currentTransitions = EmptyTransitions;
    }

    
    public void AddTransition(IState from, IState to, Func<bool> predicate)
    {
        if (_transitions.TryGetValue(from.GetType(), out var transitions) == false)
        {
            transitions = new List<Transition>();
            _transitions[from.GetType()] = transitions; //This means transitions of that type get the new List as value. It's pretty much the same as .Add()
        }
        transitions.Add(new Transition(to, predicate));
    }

    public void AddAnyTransition(IState state, Func<bool> predicate)
    {
        _anyTransitions.Add(new Transition(state, predicate));
    }

    private class Transition
    {
        public Func<bool> Condition { get; } //delegate. Can be anything. 
        public IState To { get; }

        public Transition(IState to, Func<bool> condition)
        {
            To = to;
            Condition = condition;
        }
    }

    private Transition GetTransition() //The statemachine checks for transitions every frame. This is called in the Update/Tick method
    {
        foreach (var transition in _anyTransitions) //transitions coming from any state. These don't have a from state
            if (transition.Condition()) // looks for a condition which is true. Returns the transition if it finds it
                return transition;
        
        foreach (var transition in _currentTransitions)
            if (transition.Condition())
                return transition;
        return null;
    }
}
