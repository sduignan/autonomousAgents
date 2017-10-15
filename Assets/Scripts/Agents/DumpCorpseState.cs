using UnityEngine;
using System.Collections;
using System;

public class DumpCorpseState : State<Undertaker>
{

    static readonly DumpCorpseState instance = new DumpCorpseState();

    public static DumpCorpseState Instance
    {
        get
        {
            return instance;
        }
    }

    static DumpCorpseState() { }

    private DumpCorpseState() { }

    public override void Enter(Undertaker agent)
    {
    }

    public override void Execute(Undertaker agent)
    {
        EventManager.CollectCorpse();
        agent.afterMove = WaitState.Instance;
        agent.SetLocation(Tiles.Undertakers);
        agent.ChangeState(MoveState<Undertaker>.Instance);
    }

    public override void Exit(Undertaker agent)
    {
    }
}
