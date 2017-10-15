using UnityEngine;

public sealed class GlobalUndertakerState : State<Undertaker>
{
    static readonly GlobalUndertakerState instance = new GlobalUndertakerState();

    public static GlobalUndertakerState Instance
    {
        get
        {
            return instance;
        }
    }

    static GlobalUndertakerState() { }

    private GlobalUndertakerState() { }

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
