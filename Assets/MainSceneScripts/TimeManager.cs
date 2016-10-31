using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {

    public int delay;

    private float accumlateDeltaTime;

    private int skipFrame;

	public float getDeltaTime()
    {
        return 0;
    }
    
    // Use this for initialization
	void Start () {
        skipFrame = 0;
        accumlateDeltaTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
