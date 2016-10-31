using UnityEngine;
using System.Collections;

public class ObstScript : MonoBehaviour {

    public GameObject player, marker;
    public float speed = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        playerProjection();
        //come();

        destroyCheck();
	}

    void destroyCheck()
    {
        if(transform.position.z < -5)
        {
            Destroy(gameObject);

        }
    }

    void playerProjection()
    {
        float dx = player.transform.position.x - transform.position.x;
        float dy = player.transform.position.y - transform.position.y;
        float curz = marker.transform.position.z;
        float lx = 0, rx = 0, uy = 0, ly = 0;
        if (-1f < dx && dx < 1f && -1f < dy && dy < 1f)
        {
            if(dx < 0f){
                rx = player.transform.position.x + 0.5f;
                lx = transform.position.x - 0.5f;
            }
            else{
                lx = player.transform.position.x - 0.5f;
                rx = transform.position.x + 0.5f;
            }

            if(dy < 0f){
                uy = player.transform.position.y + 0.5f;
                ly = transform.position.y - 0.5f;
            }
            else{
                ly = player.transform.position.y - 0.5f;
                uy = transform.position.y + 0.5f;
            }
            //Debug.Log(lx + ", " + rx + "- -" + uy + ", " + ly);
            marker.transform.position = new Vector3((rx + lx) / 2f, (uy + ly) / 2f, curz);
            marker.transform.localScale = new Vector3(rx - lx, uy - ly, 0.1f);
            marker.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            marker.transform.localScale = new Vector3(1f, 1f, 0.1f);
            marker.transform.localPosition = new Vector3(0f, 0f, -0.6f);
            marker.GetComponent<Renderer>().material.color = Color.white;
        }
    }
    void come()
    {
        transform.Translate(new Vector3(0f, 0f, -speed * Time.deltaTime));

        
    }
}
