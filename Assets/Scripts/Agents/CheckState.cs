using UnityEngine;
using System.Collections;
using System;

public class CheckState : State<Sheriff> {

    int checkCount;

    static readonly CheckState instance = new CheckState();

    public static CheckState Instance
    {
        get
        {
            return instance;
        }
    }

    static CheckState() { }

    private CheckState() { }

    public override void Enter(Sheriff agent)
    {
        EventManager.Look(agent.location);
        checkCount = 0;
    }

    public override void Execute(Sheriff agent)
    {
        //Stay for over half a second at each location
        if (checkCount >= 40)
        {
            agent.afterMove = CheckState.Instance;
            int loc = UnityEngine.Random.Range(0, agent.visitableLocations.Length);
            if(loc == agent.currLoc)
            {
                loc = (loc + 1) % agent.visitableLocations.Length;
            }
            agent.currLoc = loc;

            if (agent.visitableLocations[loc] == Tiles.Saloon && UnityEngine.Random.Range(0, 10) < 8)
            {
                agent.afterMove = DrinkState.Instance;
            }

            agent.SetLocation(agent.visitableLocations[loc]);
            agent.ChangeState(MoveState<Sheriff>.Instance);
        }

        checkCount++;
        EventManager.Look(agent.location);
    }

    public override void Exit(Sheriff agent)
    {
    }
}
