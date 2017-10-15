using UnityEngine;
using System.Collections.Generic;

public enum AgentTypes
{
    Sheriff,
    Outlaw,
    Undertaker
}

abstract public class Agent<T> : MonoBehaviour {

    public StateMachine<T> stateMachine;
    public GameObject icon;
    public TilingSystem tileManager;
    public Tiles location;

    public bool moving = false;

    public Vector3 vectorLocation;
    public aStar pathfinder;
    public List<Node> path;
    public State<T> afterMove;

    public Sensor senseSelf;

    abstract public void Awake();

    public void Update() {
        this.stateMachine.Update();
    }

    public void ChangeState(State<T> state)
    {
        this.stateMachine.ChangeState(state);
    }
    public void RevertState()
    {
        this.stateMachine.RevertState();
    }

    public void SetLocation(Tiles loc)
    {
        Vector3 oldLocation = vectorLocation;
        location = loc;
        vectorLocation = tileManager.FindTile(location);
        pathfinder.grid.addWalkable(vectorLocation);
        pathfinder.grid.addWalkable(oldLocation);
        pathfinder.grid.setStartEndGH(oldLocation, vectorLocation);
        path = pathfinder.findPath();
        pathfinder.grid.removeWalkable(oldLocation);
        pathfinder.grid.removeWalkable(vectorLocation);
    }
}