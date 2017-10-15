using System;
using System.Collections.Generic;

class Set
{
    public List<Node> nodes = new List<Node>();
    public int Count { get { return nodes.Count; } }
    public void insert(Node newNode)
    {
        nodes.Add(newNode);
    }

    public Node findBest()
    {
        float lowest = nodes[0].F;
        Node best = null;

        foreach (var node in nodes)
        {
            if (node.F <= lowest)
            {
                best = node;
                lowest = node.F;
            }
        }

        return best;
    }

    public void remove(Node node)
    {
        nodes.Remove(node);
    }
}
