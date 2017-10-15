using UnityEngine;
using System.Collections;

public class Corpse : MonoBehaviour {

    public GameObject icon;
    public TilingSystem tileManager;
    public SpriteRenderer srenderer;

    // Use this for initialization
    void Awake () {
        tileManager = FindObjectOfType<TilingSystem>();

        icon = Instantiate(icon, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        srenderer = icon.GetComponent<SpriteRenderer>();

        if (srenderer)
        {
            srenderer.enabled = false;
        }

        EventManager.OnShooting += new EventManager.Shooting(createCorpse);
        EventManager.OnCorpseCollection += new EventManager.CorpseCollection(removeCorpse);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void createCorpse(Tiles loc)
    {
        Debug.Log("Corpse created");
        Vector3 vectorLocation = tileManager.FindTile(loc);
        Vector3 change = vectorLocation - icon.transform.position;
        icon.transform.Translate(change);
        srenderer.enabled = true;
    }

    public void removeCorpse()
    {
        Debug.Log("Corpse destroyed");
        srenderer.enabled = false;
    }
}
