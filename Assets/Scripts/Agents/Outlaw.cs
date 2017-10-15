using UnityEngine;
using System.Collections.Generic;

public class Outlaw : Agent<Outlaw> {
    
    public int lurkTime = 0;
    public int gold = 0;
    public int lurkedEnough = 0;
    public int smokeTime = 0;
    public bool smoking = false;

    public Tiles[] lurkLocations = { Tiles.Cemetary, Tiles.Saloon, Tiles.OutlawCamp };

    override public void Awake()
    {
        location = Tiles.OutlawCamp;
        this.stateMachine = new StateMachine<Outlaw>();
        this.stateMachine.Init(this, FirstState<Outlaw>.Instance, LurkState.Instance, GlobalOutlawState.Instance);
        afterMove = LurkState.Instance;
        tileManager = FindObjectOfType<TilingSystem>();
        pathfinder = FindObjectOfType<aStar>();
        vectorLocation = tileManager.FindTile(location);
        icon = Instantiate(icon, vectorLocation, Quaternion.identity) as GameObject;
        EventManager.OnLooking += new EventManager.LookAround(LookedAt);
        EventManager.OnShooting += new EventManager.Shooting(Shot);
    }

    public void Lurk()
    {
        lurkTime++;
    }
    public void Smoke()
    {
        smokeTime--;
    }

    public void RobBank()
    {
        this.gold += Random.Range(1, 11);
        EventManager.Rob();
    }

    public Tiles GetLocation()
    {
        return location;
    }

    void LookedAt(Tiles lookLocation)
    {
        if (!moving && lookLocation == location)
        {
            Debug.Log("Oh no! The Sheriff!");
            EventManager.Seen(AgentTypes.Outlaw);
        }
    }

    void Shot(Tiles loc)
    {
        gold = 0;
        ChangeState(LurkState.Instance);
        location = Tiles.OutlawCamp;
        vectorLocation = tileManager.FindTile(location);
        Vector3 change = vectorLocation - icon.transform.position;
        icon.transform.Translate(change);
    }
}
