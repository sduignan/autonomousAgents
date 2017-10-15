using UnityEngine;

public sealed class RobState : State<Outlaw>
{
    int robTime;

    static readonly RobState instance = new RobState();

    public static RobState Instance
    {
        get
        {
            return instance;
        }
    }

    static RobState() { }

    private RobState() { }

    public override void Enter(Outlaw agent)
    {
        robTime = 0;
        Debug.Log("Hands up, this is a stick up!");
    }

    public override void Execute(Outlaw agent)
    {
        agent.RobBank();
        if (robTime == 0)
        {
            Debug.Log("PUT THE MONEY IN THE BAGS AND NO ONE GETS HURT!");
        }
        robTime++;
        if (robTime > 60)
        {
            int loc = UnityEngine.Random.Range(0, agent.lurkLocations.Length);
            agent.SetLocation(agent.lurkLocations[loc]);
            agent.afterMove = LurkState.Instance;
            agent.ChangeState(MoveState<Outlaw>.Instance);
        }
    }

    public override void Exit(Outlaw agent)
    {
        Debug.Log("...now to make a clean getaway!!");
        
    }
}
