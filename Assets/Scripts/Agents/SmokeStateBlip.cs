using UnityEngine;

public sealed class SmokeStateBlip : State<Outlaw>
{
    static readonly SmokeStateBlip instance = new SmokeStateBlip();

    public static SmokeStateBlip Instance
    {
        get
        {
            return instance;
        }
    }

    static SmokeStateBlip() { }

    private SmokeStateBlip() { }

    public override void Enter(Outlaw agent)
    {
        agent.smoking = true;
        Debug.Log("Time for a cigarette break.");
        agent.smokeTime = Random.Range(1, 6);
    }

    public override void Execute(Outlaw agent)
    {
        agent.Smoke();
        Debug.Log("Oh yeah, tasty cancer sticks.");
        if (agent.smokeTime <= 0)
        {
            agent.RevertState();
        }
    }

    public override void Exit(Outlaw agent)
    {
        agent.smoking = false;
        Debug.Log("*stubbs out cigarette*");
    }
}
