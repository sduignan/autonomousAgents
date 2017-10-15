using UnityEngine;
using System.Collections.Generic;
using System;

public sealed class MoveState<T> : State<T> where T : Agent<T>
{
    Node current;
    List<Node> path;
    int partialStep;
    public int stepsPerSecond = 3;
    public int framesPerStep;

    static readonly MoveState<T> instance = new MoveState<T>();

    public static MoveState<T> Instance
    {
        get
        {
            return instance;
        }
    }

    static MoveState() { }

    private MoveState() { }

    public override void Enter(T agent)
    {
        agent.moving = true;
        if(agent.path.Count > 0)
        {
            partialStep = 0;
            path = agent.path;
            current = path[0];
            path.Remove(current);
            framesPerStep = 60 / stepsPerSecond;
        }
    }

    public override void Execute(T agent)
    {
        if(path.Count > 0)
        {
            partialStep++;
            Vector3 increment = (path[0].location - current.location) / (float)framesPerStep;
            agent.icon.transform.Translate(increment);

            if (partialStep >= framesPerStep)
            {
                if (path.Count > 1)
                {
                    partialStep = 0;
                    current = path[0];
                    path.Remove(current);
                }
                else
                {
                    agent.ChangeState(agent.afterMove);
                }
            }
        }
        else
        {
            agent.ChangeState(agent.afterMove);
        }

    }

    public override void Exit(T agent)
    {
        agent.moving = false;
    }
}
