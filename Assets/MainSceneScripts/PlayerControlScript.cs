using UnityEngine;
using System.Collections;

public class PlayerControlScript : MonoBehaviour {
    
    public float minX = -5f, maxX = 5f, minY = -5f, maxY = 5f;
    public float moveSpeed, rotSpeed, rotDivdisor = 15f;

    private Vector2 state = new Vector2(1,1); // 좌우가 충돌시 x가 0 위아래가 충돌시 y가 0

    public Vector2 getState()
    {
        return state;
    }

    float xpos = 0, ypos = 0;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    float dt;
    void Update()
    {
        dt = Time.deltaTime;
        //movePos();
        moveSight();
    }
    
    void movePos()
    {
        xpos += Input.GetAxis("Horizontal") * dt * moveSpeed;
        ypos += Input.GetAxis("Vertical") * dt * moveSpeed;

        if (xpos > maxX){
            xpos = maxX;
        }
        if (ypos > maxY){
            ypos = maxY;
        }
        if (xpos < minX){
            xpos = minX;
        }
        if (ypos < minY){
            ypos = minY;
        }
        transform.position = new Vector3(xpos, ypos, transform.position.z);
    }
    void moveSight()
    {
        Vector3 mPos = Input.mousePosition;
        transform.rotation = Quaternion.identity;
        //float mx = Input.GetAxis("Mouse X");
        // float my = Input.GetAxis("Mouse Y");

        //Vector3 rot = new Vector3(-my * rotSpeed, mx * rotSpeed, 0f);
        Vector3 mRot = new Vector3((Screen.height/2f - mPos.y) / rotDivdisor, (mPos.x - Screen.width/2f) / rotDivdisor, 0f);
        transform.Rotate(mRot);
    }

    void OnTriggerEnter(Collider obs)
    {
        if (obs.tag == "Block")
        {
            Debug.LogError("mmmm");
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().blockCollision();
        }
        if (obs.name == "LeftWall" || obs.name == "RightWall")
            state.x = -10;
        else if (obs.name == "UpperWall" || obs.name == "LowerWall")
            state.y = -10;
    }

    void OnTriggerStay(Collider obs)
    {
    }

    void OnTriggerExit(Collider obs)
    {
        if (obs.name == "LeftWall" || obs.name == "RightWall")
            state.x = 1;
        else if (obs.name == "UpperWall" || obs.name == "LowerWall")
            state.y = 1;
    }
}
