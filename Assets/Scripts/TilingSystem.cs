using Lean; //from Unity asset "LeanPool" - freely available in the Asset Store; used here for object pooling
using System.Collections.Generic;
using UnityEngine;

public class TilingSystem : MonoBehaviour {
    
	public Vector2 MapSize;
	public Vector2 CurrentPosition;
	public Vector2 ViewPortSize;

    public GameObject plains, undertakers, outlawCamp, sherrifsOffice, cemetary, bank, saloon, mountains;

    private Transform Boardholder;
    private List<TileSprite> locationPositions = new List<TileSprite>();
    private List<Vector3> gridPositions = new List<Vector3>();
    private List<Vector3> mountainPositions = new List<Vector3>();


    public Vector3 FindTile(Tiles tile)
    {
        foreach (TileSprite tileSprite in locationPositions)
        {
            if (tileSprite.TileType == tile) return tileSprite.location;
        }
        return new Vector3(0, 0, 0);
    }

    void InitialiseList()
    {
        gridPositions.Clear();
        locationPositions.Clear();
        for (int x = 0; x < MapSize.x; x++)
        {
            for(int y=0; y < MapSize.y; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }

    }

    //create a map of size MapSize of unset tiles
    private void DefaultTiles() {
        Boardholder = new GameObject("Board").transform;
        for (var y = 0; y < MapSize.y; y++)
        {
            for (var x = 0; x < MapSize.x; x++)
            {
                GameObject instance = Instantiate(plains, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(Boardholder);
            }
        }
    }

    Vector3 RandMapLoc()
    {
        int randIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPos = gridPositions[randIndex];
        gridPositions.RemoveAt(randIndex);
        return randomPos;
    }

    void RandomLayout(GameObject[] LocationArray) {
        for(int i=0; i<LocationArray.Length; i++)
        {
            GameObject loc = LocationArray[i];
            Vector3 position = RandMapLoc();
            Instantiate(loc, position, Quaternion.identity);
            TileSprite temp = loc.GetComponent<TileSprite>();
            temp.location = position;
            locationPositions.Add(temp);
        }

        int mountainCount = Random.Range(0, 6);
        for(int i=0; i<mountainCount; i++)
        {
            Vector3 position = RandMapLoc();
            Instantiate(mountains, position, Quaternion.identity);
            mountainPositions.Add(position);
        }

    }

    private void setupPathfinder()
    {
        int[,] walkableMap = new int[(int)MapSize.x, (int)MapSize.y];
        for (int i = 0; i < MapSize.x; i++)
        {
            for (int j = 0; j < MapSize.y; j++)
            {
                walkableMap[i, j] = 0;
            }
        }
        foreach (var place in locationPositions)
        {
            walkableMap[(int)place.location.x, (int)place.location.y] = 2;
        }

        foreach (var pos in mountainPositions)
        {
            walkableMap[(int)pos.x, (int)pos.y] = 1;
        }

        Grid grid = new Grid();
        grid.setup(walkableMap, (int)MapSize.x, (int)MapSize.y);
        grid.initGrid();

        aStar pathfinder = FindObjectOfType<aStar>();
        pathfinder.grid = grid;
    }

    public void SetupMap()
    {
        Debug.Log("Creation");
        DefaultTiles();
        InitialiseList();
        GameObject[] locationArray = { undertakers, outlawCamp, sherrifsOffice, cemetary, bank, saloon };
        RandomLayout(locationArray);
        setupPathfinder();
    }

}
