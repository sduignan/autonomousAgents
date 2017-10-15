using UnityEngine;
using System.Collections.Generic;

public class aStar : MonoBehaviour {
    
    public List<Node> path;
    public Grid grid;

    public void setGrid(Grid _grid)
    {
        this.grid = _grid;
    }

    public List<Node> findPath()
    {
        grid.reset();
        
        path = new List<Node>();
        Set openlist = new Set();
        openlist.insert(grid.start);

        Node currentNode = grid.start;

        while (openlist.Count > 0 && !currentNode.same(grid.end))
        {
            currentNode.state = NodeState.Closed;
            openlist.remove(currentNode);

            foreach (var neighbour in currentNode.Neighbours)
            {
                if (neighbour.state == NodeState.Untested)
                {
                    openlist.insert(neighbour);
                    neighbour.state = NodeState.Open;
                    neighbour.parent = currentNode;
                    neighbour.G = currentNode.G + currentNode.cost;
                } else if (neighbour.state == NodeState.Open)
                {
                    if (currentNode.G + currentNode.cost < neighbour.G)
                    {
                        neighbour.parent = currentNode;
                        neighbour.G = currentNode.G + currentNode.cost;
                    }
                }
            }
            
            Node newCurrent = openlist.findBest();

            if(newCurrent != null)
            {
                currentNode = newCurrent;
            }            

        }

        if (currentNode.same(grid.end))
        {
            while (!currentNode.same(grid.start))
            {
                path.Add(currentNode);
                currentNode = currentNode.parent;
            }
            path.Add(currentNode);
            path.Reverse();
        }

        return path;
    }

}
