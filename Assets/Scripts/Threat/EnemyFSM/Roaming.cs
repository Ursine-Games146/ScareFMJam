using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roaming : IState
{
    public float timer;
    public void Tick()
    {
        timer += Time.deltaTime;
    }

    public void OnEnter()
    {
        timer = 0f;
    }

    public void OnExit()
    {
        timer = 0f;
    }
}
