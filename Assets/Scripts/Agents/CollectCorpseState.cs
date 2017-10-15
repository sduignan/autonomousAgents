using UnityEngine;
using System.Collections;
using System;

public class CollectCorpse : State<Undertaker> {

    static readonly CollectCorpse instance = new CollectCorpse();

    public static CollectCorpse Instance
    {
        get
        {
            return instance;
        }
    }

    static CollectCorpse() { }

    private CollectCorpse() { }

    public override void Enter(Undertaker agent)
    {
    }

    public override void Execute(Undertaker agent)
    {
        EventManager.CollectCorpse();
        agent.afterMove = DumpCorpseState.Instance;
        agent.SetLocation(Tiles.Cemetary);
        agent.ChangeState(MoveState<Undertaker>.Instance);
    }

    public override void Exit(Undertaker agent)
    {
    }
}
