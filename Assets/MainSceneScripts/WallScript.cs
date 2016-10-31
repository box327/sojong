using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {
    public int myPos;
	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    bool added = false;
	void Update () {
        if (!added)
        {
            GameObject.Find("WallManager").GetComponent<WallColorManagerScript>().setWall(myPos, gameObject);
        }
	}

    public void SetColor(Color c)
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = c;
    }
}
