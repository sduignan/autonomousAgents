using UnityEngine;
using System.Collections;
using System;

public class FirstState<T> : State<T> where T : Agent<T> {

    static readonly FirstState<T> instance = new FirstState<T>();

    public static FirstState<T> Instance
    {
        get
        {
            return instance;
        }
    }

    static FirstState() { }
    private FirstState() { }

    public override void Enter(T agent)
    {
    }

    public override void Execute(T agent)
    {
        agent.vectorLocation = agent.tileManager.FindTile(agent.location);
        Vector3 change = agent.vectorLocation - agent.icon.transform.position;
        agent.icon.transform.Translate(change);
        agent.ChangeState(agent.afterMove);
    }

    public override void Exit(T agent)
    {
    }
}
