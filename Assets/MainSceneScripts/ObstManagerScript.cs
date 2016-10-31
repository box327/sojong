using UnityEngine;
using System.Collections;

public class ObstManagerScript : MonoBehaviour {
    public GameObject ObstaclePrefab;
    public GameObject player;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //randomShoot();
	}


    const float delayBase = 2f, delayAmplitude = .5f;
    float lastShooted = 0f, nextDelay = delayBase;
    void randomShoot()
    {
        if(lastShooted < nextDelay)
        {
            lastShooted += Time.deltaTime;
        }
        else
        {
            lastShooted -= nextDelay;
            nextDelay = delayBase + Random.Range(-delayAmplitude, delayAmplitude);

            Vector3 newPos = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f), 25f);
            GameObject newObs = Instantiate(ObstaclePrefab, newPos, Quaternion.identity) as GameObject;
            newObs.GetComponent<ObstScript>().player = player;
        }
    }


    void programmedShoot()
    {

    }
}
