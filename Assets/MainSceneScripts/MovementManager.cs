using UnityEngine;
using System.Collections;

public class MovementManager : MonoBehaviour {

    public float speed;
    public float accSpeed;
    public float limitSpeed;
    public int delay;

    public bool rotationflag;

    public bool movePlayerOrMap;

    public OVRCameraRig ThirdCamera;

    private float adjustDeltaTime = 0;
    private int delayedTime = 0;

    private float rotate = 0;

    // Use this for initialization
    void Start () {

        //++ EXAMPLE CODE
        xSpd = new float[38] {0f,-0.3f,0f,0.3f,0f,0.3f,0f,-0.3f,0f,0f,0f,0f,0f,0.3f,0f,-0.3f,0f,-0.3f,0f,0f,0f,0.3f,0f,0.3f,0f,0f,0f,-0.3f,0f,0f,0.3f,0f,0f,0f,-0.6f,0f,0f,0f};
        ySpd = new float[38] {0f,0f,0f,0.3f,0f,-0.3f,0f,-0.3f,0f,0.3f,0f,-0.3f,0f, 0f,0f,0f,0f,0.3f,0f,-0.3f,0f,0f,0f,0f,0f,0.3f,0f,0f,0f,0f,-0.3f,0f,0.6f,0f,0f,0f,-0.6f,0f};
        time = new float[38] { 8f, 1.5f, 1.9f, 1.5f, 1.5f, 1.5f, 1.9f, 1.5f, 1.9f, 1.5f, 1.9f, 1.5f, 1.9f, 1.5f, 1.9f, 1.5f, 1.9f, 1.5f, 1.9f, 1.5f, 1.9f, 1.5f, 1.9f, 1.5f, 1.9f, 1.5f, 1.9f, 1.5f, 1.9f, 1.5f, 1.9f, 1.5f, 1.9f, 1.5f, 1.9f, 1.5f, 1.9f,1.5f};
        //
	}
	
	// Update is called once per frame
	void Update () {

        
        if (delay > delayedTime)
        {
            delayedTime++;
            adjustDeltaTime += Time.deltaTime;
            
        }
        else
        {
            adjustDeltaTime += Time.deltaTime;
            speed += accSpeed * adjustDeltaTime;
            if (speed > limitSpeed)
                speed = limitSpeed;


            float adjustSpeed = speed * adjustDeltaTime;

            GameObject player = GameObject.FindGameObjectWithTag("Player");

            Vector2 state = player.GetComponent<PlayerControlScript>().getState();
            

            move(adjustSpeed,state);

            adjustDeltaTime = 0;
            delayedTime = 0;
        }
        
	}

    //++
    public bool playerControl;
    float[] xSpd, ySpd, time;
    int controlIdx = -1;
    float frontTimer = 0f;
    //

    private void move(float adjustSpeed,Vector2 stop)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        GameObject subCamera = GameObject.FindGameObjectWithTag("SubCamera");


        Vector3 forward = camera.GetComponentInChildren<Camera>().transform.forward;

        if (movePlayerOrMap)
        {
            GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");

            GameObject spawnLoc = GameObject.FindGameObjectWithTag("Respawn");
            GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
            GameObject DestroyLoc = GameObject.FindGameObjectWithTag("Destroy");


            foreach (GameObject block in blocks)
            {
                block.transform.position = new Vector3(block.transform.position.x - adjustSpeed * forward.x * stop.x, block.transform.position.y - adjustSpeed * forward.y * stop.y, block.transform.position.z - adjustSpeed);

            }

            //spawnLoc.transform.position = new Vector3(spawnLoc.transform.position.x - adjustSpeed * forward.x * stop.x, spawnLoc.transform.position.y - adjustSpeed * forward.y * stop.y, spawnLoc.transform.position.z);
            //DestroyLoc.transform.position = new Vector3(DestroyLoc.transform.position.x - adjustSpeed * forward.x * stop.x, DestroyLoc.transform.position.y - adjustSpeed * forward.y * stop.y, DestroyLoc.transform.position.z);

            foreach (GameObject wall in walls)
            {
                wall.transform.position = new Vector3(wall.transform.position.x - adjustSpeed * forward.x * stop.x, wall.transform.position.y - adjustSpeed * forward.y * stop.y, wall.transform.position.z);

            }
        }
        else
        {
            GameObject spawnLoc = GameObject.FindGameObjectWithTag("Respawn");
            GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
            GameObject DestroyLoc = GameObject.FindGameObjectWithTag("Destroy");

            //++
            float pnx = player.transform.position.x + adjustSpeed * forward.x * stop.x,
                pny = player.transform.position.y + adjustSpeed * forward.y * stop.y;
            if(rotationflag)
            {
                player.GetComponentInChildren<Transform>().Rotate(new Vector3(0, 0, rotate));
                rotate = rotate + 0.3f;
            }

            if (!playerControl)
            {
                // change this code to make 'degree of control' part.
                if(controlIdx < xSpd.Length)
                {
                    if(controlIdx == -1 || frontTimer < 0f)
                    {
                        controlIdx++;
                        frontTimer = time[controlIdx];
                    }

                    frontTimer -= Time.deltaTime;
                    pnx = player.transform.position.x + adjustSpeed * xSpd[controlIdx] * stop.x;
                    pny = player.transform.position.y + adjustSpeed * ySpd[controlIdx] * stop.y;
                }
                else{
                    pnx = 0;
                    pny = 0;
                }
            }
            player.transform.position = new Vector3(
                    pnx,
                    pny,
                    player.transform.position.z + adjustSpeed);
            //


            spawnLoc.transform.position = new Vector3(spawnLoc.transform.position.x, spawnLoc.transform.position.y, spawnLoc.transform.position.z + adjustSpeed);
            DestroyLoc.transform.position = new Vector3(DestroyLoc.transform.position.x, DestroyLoc.transform.position.y, DestroyLoc.transform.position.z + adjustSpeed);

            ThirdCamera.transform.position = new Vector3(ThirdCamera.transform.position.x, ThirdCamera.transform.position.y, ThirdCamera.transform.position.z + adjustSpeed);

            foreach (GameObject wall in walls)
            {
                wall.transform.position = new Vector3(wall.transform.position.x, wall.transform.position.y, wall.transform.position.z + adjustSpeed);

            }

        }
    }
}
