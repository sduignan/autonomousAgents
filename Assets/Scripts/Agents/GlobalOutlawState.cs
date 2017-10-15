using UnityEngine;

public sealed class GlobalOutlawState : State<Outlaw>
{
    static readonly GlobalOutlawState instance = new GlobalOutlawState();

    public static GlobalOutlawState Instance
    {
        get
        {
            return instance;
        }
    }

    static GlobalOutlawState() { }

    private GlobalOutlawState() { }

    public override void Enter(Outlaw agent)
    {
    }

    public override void Execute(Outlaw agent)
    {
        if(Random.Range(0, 200) == 10 && !agent.smoking && !agent.moving)
        {
            Debug.Log("Craving a cigarette.");
            agent.ChangeState(SmokeStateBlip.Instance);
        }
    }

    public override void Exit(Outlaw agent)
    {
    }
}
