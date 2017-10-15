using UnityEngine;
using System.Collections;
using System;

public class WaitState : State<Undertaker> {

    static readonly WaitState instance = new WaitState();

    public static WaitState Instance
    {
        get
        {
            return instance;
        }
    }

    static WaitState() { }

    private WaitState() { }

    public override void Enter(Undertaker agent)
    {
    }

    public override void Execute(Undertaker agent)
    {
    }

    public override void Exit(Undertaker agent)
    {
    }
}
