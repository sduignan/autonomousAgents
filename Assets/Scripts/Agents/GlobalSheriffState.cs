using UnityEngine;

public sealed class GlobalSheriffState : State<Sheriff>
{
    static readonly GlobalSheriffState instance = new GlobalSheriffState();

    public static GlobalSheriffState Instance
    {
        get
        {
            return instance;
        }
    }

    static GlobalSheriffState() { }

    private GlobalSheriffState() { }

    public override void Enter(Sheriff agent)
    {
    }

    public override void Execute(Sheriff agent)
    {
    }

    public override void Exit(Sheriff agent)
    {
    }
}
