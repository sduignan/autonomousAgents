using UnityEngine;
using System.Collections;
using System;

public class Undertaker : Agent<Undertaker> {
    public override void Awake()
    {
        location = Tiles.Undertakers;
        this.stateMachine = new StateMachine<Undertaker>();
        this.stateMachine.Init(this, FirstState<Undertaker>.Instance, WaitState.Instance, GlobalUndertakerState.Instance);
        afterMove = WaitState.Instance;
        tileManager = FindObjectOfType<TilingSystem>();
        pathfinder = FindObjectOfType<aStar>();
        vectorLocation = tileManager.FindTile(location);
        icon = Instantiate(icon, vectorLocation, Quaternion.identity) as GameObject;
        EventManager.OnShooting += new EventManager.Shooting(deadBody);
    }

    public void deadBody(Tiles loc)
    {
        afterMove = CollectCorpse.Instance;
        SetLocation(loc);
        ChangeState(MoveState<Undertaker>.Instance);
    }
}
