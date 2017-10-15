using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum NodeState
{
    Untested,
    Open,
    Closed
}

public class Node {

    public Node parent;
    public Vector2 location;
    public bool walkable = false;
    public List<Node> Neighbours;
    public float cost;
    public float G { get; set; }
    public float H { get; set; }
    public float F { get { return this.G + this.H; } }

    public NodeState state;

    public Node()
    {
        cost = 1.0f;
        Neighbours = new List<Node>();
        walkable = false;
        location = new Vector2(0, 0);
        parent = null;
        state = NodeState.Untested;
    }


    public Node(float _cost, bool _walkable, Vector2 _location, Node _parent)
    {
        parent = _parent;
        Neighbours = new List<Node>();
        location = _location;
        walkable = _walkable;
        cost = _cost;
        state = NodeState.Untested;
    }

    public bool same(Node other)
    {
        return other.location == location;
    }

    internal class NodeEqualityComparer: IEqualityComparer<Node>
    {
        public bool Equals(Node x, Node y)
        {
            return x.location == y.location;
        }

        public int GetHashCode(Node obj)
        {
            return obj.location.ToString().GetHashCode();
        }
    }

}
