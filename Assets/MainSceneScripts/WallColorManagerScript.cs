using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallColorManagerScript : MonoBehaviour {

    // 0, 1, 2, 3;
    ArrayList[] walls;

    double lePos = -5.0, riPos = 5.0, // x
           upPos = 5.0, loPos = -5.0; // y

    public GameObject playerObj;
 
    int closestWall = 3;
    // Use this for initialization
    void Start () {
        
    }
    void Awake(){
        dist = new double[4] { 0, 0, 0, 0 };
        walls = new ArrayList[4];
        walls[0] = new ArrayList();
        walls[1] = new ArrayList();
        walls[2] = new ArrayList();
        walls[3] = new ArrayList();
    }

    // Update is called once per frame
    double[] dist;
    bool ifTouched = false;
    bool lastTouched;
	void Update (){
        double px = playerObj.transform.position.x;
        double py = playerObj.transform.position.y;
        dist[0] = px - lePos;
        dist[1] = riPos - px;
        dist[2] = upPos - py;
        dist[3] = py - loPos;

        int lastClosest = closestWall;
        for (int i = 0; i < 4; ++i){
            if(dist[i] < dist[closestWall]){
                closestWall = i;
                if (dist[i] < 0.5f) { // ERROR on recognizing touch
                    ifTouched = true;
                }
                else
                {
                    ifTouched = false;
                }
            }
        }
        
        if (lastClosest != closestWall || lastTouched != ifTouched){
            //Debug.Log(closestWall + " go ");
            foreach (GameObject x in walls[lastClosest]){
                x.GetComponent<WallScript>().SetColor(Color.white);
            }
            foreach (GameObject x in walls[closestWall]){
                if(!ifTouched) x.GetComponent<WallScript>().SetColor(Color.yellow);
                else x.GetComponent<WallScript>().SetColor(Color.red);
            }
        }
        lastTouched = ifTouched;
    }
    public void setWall(int i, GameObject g){
        walls[i].Add(g);
    }
}
