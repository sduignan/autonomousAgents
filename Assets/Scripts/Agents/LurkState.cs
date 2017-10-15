using UnityEngine;

public sealed class LurkState : State<Outlaw>
{
    static readonly LurkState instance = new LurkState();

    public static LurkState Instance
    {
        get
        {
            return instance;
        }
    }

    static LurkState() { }

    private LurkState() { }

    public override void Enter(Outlaw agent)
    {
        Debug.Log("Starting to lurk...");
        agent.lurkedEnough = Random.Range(0, 100);
    }

    public override void Execute(Outlaw agent)
    {
        agent.Lurk();
        if (agent.lurkTime >= agent.lurkedEnough)
        {
            agent.afterMove = RobState.Instance;
            Debug.Log("...off to rob the Bank!");
            agent.SetLocation(Tiles.Bank);
            agent.ChangeState(MoveState<Outlaw>.Instance);
        }
    }

    public override void Exit(Outlaw agent)
    {
        agent.lurkTime = 0;
    }
}
