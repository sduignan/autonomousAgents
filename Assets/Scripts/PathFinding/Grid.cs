using UnityEngine;
using System.Collections.Generic;

public class Grid {

    public int[,] map { get; set; }
    public int width, height;
    public Node start, end;
    public List<Node> nodes { get; set; }

	// Use this for initialization
	public void initGrid () {
	    for (int i=0; i<width; i++)
        {
            for (int j=0; j<height; j++)
            {
                float cost = 2;
                if(map[i, j] == 0)
                {
                    cost = 1;
                }
                bool walkable = false;
                if(map[i,j] < 2)
                {
                    walkable = true;
                }
                nodes.Add(new Node(cost, walkable, new Vector2(i, j), null));
            }
        }

        //Neighbours
        for(int i=0; i<width; i++)
        {
            for(int j=0; j<height; j++)
            {
                if (i > 0 && nodes[(i - 1) * height + j].walkable)
                {
                    nodes[i * height + j].Neighbours.Add(nodes[(i - 1) * height + j]);
                }
                if (i < width - 1 && nodes[(i + 1) * height + j].walkable)
                {
                    nodes[i * height + j].Neighbours.Add(nodes[(i + 1) * height + j]);
                }
                if (j > 0 && nodes[i * height + j - 1].walkable)
                {
                    nodes[i * height + j].Neighbours.Add(nodes[i * height + j - 1]);
                }
                if (j < height - 1 && nodes[i * height + j + 1].walkable)
                {
                    nodes[i * height + j].Neighbours.Add(nodes[i * height + j + 1]);
                }
            }
        }
	}

    public void setup(int[,] _map, int _width, int _height)
    {
        map = _map;
        width = _width;
        height = _height;
        nodes = new List<Node>();
    }

    public void setStartEndGH(Vector2 _start, Vector2 _end)
    {
        start = nodes[(int)_start.x * height + (int)_start.y];
        end = nodes[(int)_end.x * height + (int)_end.y];

        for(int i=0; i<nodes.Count; i++)
        {
            nodes[i].G = Mathf.Abs(nodes[i].location.x - _start.x) + Mathf.Abs(nodes[i].location.y - _start.y);
            nodes[i].H = Mathf.Abs(nodes[i].location.x - _end.x) + Mathf.Abs(nodes[i].location.y - _end.y);
        }
    }

    public void reset()
    {
        foreach(var node in nodes)
        {
            node.state = NodeState.Untested;
        }
    }

    public void addWalkable(Vector2 location)
    {
        int x, y;
        x = (int)location.x;
        y = (int)location.y;
        if (!nodes[x * height + y].walkable)
        {
            nodes[x * height + y].walkable = true;
            nodes[x * height + y].cost = 1;
            if (x > 0 && nodes[(x - 1) * height + y].walkable)
            {
                nodes[x * height + y].Neighbours.Add(nodes[(x - 1) * height + y]);
                nodes[(x - 1) * height + y].Neighbours.Add(nodes[x * height + y]);
            }
            if (x < width - 1 && nodes[(x + 1) * height + y].walkable)
            {
                nodes[x * height + y].Neighbours.Add(nodes[(x + 1) * height + y]);
                nodes[(x + 1) * height + y].Neighbours.Add(nodes[x * height + y]);
            }
            if (y > 0 && nodes[x * height + y - 1].walkable)
            {
                nodes[x * height + y].Neighbours.Add(nodes[x * height + y - 1]);
                nodes[x * height + y - 1].Neighbours.Add(nodes[x * height + y]);
            }
            if (y < height - 1 && nodes[x * height + y + 1].walkable)
            {
                nodes[x * height + y].Neighbours.Add(nodes[x * height + y + 1]);
                nodes[x * height + y + 1].Neighbours.Add(nodes[x * height + y]);
            }
        }
    }

    public void removeWalkable(Vector2 location)
    {
        int x, y;
        x = (int)location.x;
        y = (int)location.y;
        if (nodes[x * height + y].walkable)
        {
            nodes[x * height + y].walkable = false;
            nodes[x * height + y].Neighbours.Clear();
            if (x > 0 && nodes[(x - 1) * height + y].walkable)
            {
                nodes[(x - 1) * height + y].Neighbours.Remove(nodes[x * height + y]);
            }
            if (x < width - 1 && nodes[(x + 1) * height + y].walkable)
            {
                nodes[(x + 1) * height + y].Neighbours.Remove(nodes[x * height + y]);
            }
            if (y > 0 && nodes[x * height + y - 1].walkable)
            {
                nodes[x * height + y - 1].Neighbours.Remove(nodes[x * height + y]);
            }
            if (y < height - 1 && nodes[x * height + y + 1].walkable)
            {
                nodes[x * height + y + 1].Neighbours.Remove(nodes[x * height + y]);
            }
        }
    }
}
