using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public TilingSystem tilingScript;



	// Use this for initialization
	void Awake () {
        tilingScript = GetComponent<TilingSystem>();
        InitWorld();
	}

    void InitWorld()
    {
        tilingScript.SetupMap();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
