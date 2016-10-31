using UnityEngine;
using System.Collections;

public class DestroyBlock : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");

        bool destroied = false;
        foreach (GameObject block in blocks)
        {
            if (block.transform.position.z < gameObject.transform.position.z)
            {
                Destroy(block);
                destroied = true;
                GameObject.Find("ScoreManager").GetComponent<ScoreManager>().blockDestroy();
            }

        }
        if (destroied)
        {
            GameObject.Find("PLT").GetComponent<lightFlickerScript>().doFlicker(0.3f);
        }

    }
}
