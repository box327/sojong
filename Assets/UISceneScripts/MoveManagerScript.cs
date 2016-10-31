using UnityEngine;
using System.Collections;

public class MoveManagerScript : MonoBehaviour
{

    public float speed;
    public float accSpeed;
    public float limitSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        speed += accSpeed;
        if (speed > limitSpeed)
            speed = limitSpeed;


        float adjustSpeed = speed * Time.deltaTime;

        GameObject camera = GameObject.Find("Camera");
        Vector3 forward = camera.transform.forward;


        
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //GameObject spawnLoc = GameObject.FindGameObjectWithTag("Respawn");
        //GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        //GameObject DestroyLoc = GameObject.FindGameObjectWithTag("Destroy");

        /*
        player.transform.position = new Vector3(
        player.transform.position.x + adjustSpeed * forward.x,
        player.transform.position.y + adjustSpeed * forward.y,
        player.transform.position.z + adjustSpeed);
        Debug.Log(forward.x + "  " + adjustSpeed);
        */
    }
}
