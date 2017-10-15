using UnityEngine;
using System.Collections;
using System;

public class Sheriff : Agent<Sheriff> {

    public Tiles[] visitableLocations = {Tiles.Bank, Tiles.Cemetary, Tiles.Saloon, Tiles.SheriffsOffice, Tiles.Undertakers };
    public int currLoc = 3;

    public override void Awake()
    {
        location = Tiles.SheriffsOffice;
        this.stateMachine = new StateMachine<Sheriff>();
        this.stateMachine.Init(this, FirstState<Sheriff>.Instance, CheckState.Instance, GlobalSheriffState.Instance);
        afterMove = CheckState.Instance;
        tileManager = FindObjectOfType<TilingSystem>();
        pathfinder = FindObjectOfType<aStar>();
        vectorLocation = tileManager.FindTile(location);
        icon = Instantiate(icon, vectorLocation, Quaternion.identity) as GameObject;
        EventManager.OnSeeing += new EventManager.Seeing(seeSomeone);
    }

    void seeSomeone(AgentTypes seenAgent)
    {
        if(seenAgent == AgentTypes.Outlaw)
        {
            Debug.Log("BANG!");
            EventManager.Shoot(location);
        } else
        {
            Debug.Log("Howdy Citizen!");
        }
    }
}
