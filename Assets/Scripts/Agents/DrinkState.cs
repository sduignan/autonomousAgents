using UnityEngine;
using System.Collections;
using System;

public class DrinkState : State<Sheriff>
{

    static readonly DrinkState instance = new DrinkState();

    public static DrinkState Instance
    {
        get
        {
            return instance;
        }
    }

    static DrinkState() { }

    private DrinkState() { }

    public override void Enter(Sheriff agent)
    {
        Debug.Log("I'm feeling mighty thirsty!");
    }

    public override void Execute(Sheriff agent)
    {
        if (UnityEngine.Random.Range(0, 100) > 1)
        {
            Debug.Log("More beer!");
        }
        else
        {
            agent.afterMove = CheckState.Instance;
            int loc = UnityEngine.Random.Range(0, agent.visitableLocations.Length);
            if (loc == agent.currLoc)
            {
                loc = (loc + 1) % agent.visitableLocations.Length;
            }
            agent.currLoc = loc;
            agent.SetLocation(agent.visitableLocations[loc]);
            agent.ChangeState(MoveState<Sheriff>.Instance);
        }
    }

    public override void Exit(Sheriff agent)
    {
        Debug.Log("I beter get after that nasty outlaw!");
    }
}