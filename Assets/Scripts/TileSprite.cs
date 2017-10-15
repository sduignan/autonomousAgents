using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class TileSprite : MonoBehaviour {
    public Tiles TileType;
    public string Name;
    public Vector3 location;

    public TileSprite() {
        Name = "Plains";
        TileType = Tiles.Plains;
	}

	public TileSprite(string name, Sprite image, Tiles tileType) {
        this.TileType = tileType;
        this.Name = name;
	}
}
