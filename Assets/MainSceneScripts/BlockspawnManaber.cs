using UnityEngine;
using System.Collections;

public class BlockspawnManaber : MonoBehaviour {

    public GameObject Block;

    public int spawnTime;

    float timer = 0;

    int layer = 0;

    bool[,] spawnList;

    // Use this for initialization
    void Start()
    {
        spawnList = new bool[19, 9]
        { 
            //369
            //258
            //147
            //tutorial - 1
          // { false, false, false, false, false, false, false, false, false },
            //tutorial - 1(5)
            { true, false, false, false, false, false, false, false, false },//1
            { false, false, true, false, false, false, false, false, false },//3
            { false, false, false, false, true, false, false, false, false },//5
            { false, false, false, false, false, false, true, false, false },//7
            { false, false, false, false, false, false, false, false, true },//9


            //one line  - (7)
           { true, true, true, false, false, false, false, false, false },//123
           { false, false, true, false, false, true, false, false, true },//369
           { false, true, false, false, true, false, false, true, false },//258
           { false, false, false, false, false, false, true, true, true },//789
           { true, false, false, true, false, false, true, false, false },//147

           { false, false, true, false, true, false, true, false, false },//357
           { true, false, false, false, true, false, false, false, true }, //159

           //two-line ㄱshape
            { true, true, true, false, false, true, false, false, true },//12369
            { true, false, false, true, false, false, true, true, true },//14798

            //end
            { true, true, true, true, false, true, true, true, true },//5
            { true, true, true, true, true, true, false, true, true },//7
            { true, true, true, true, true, true, true, true, false },//9
            { true, true, false, true, true, true, true, true, true },//3
            { false, true, true, true, true, true, true, true, true },//1




        };
	}
	
	// Update is called once per frame
	void Update () {
        timer++;

        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;
        float z = gameObject.transform.position.z;

        float distance = 2;

        if (timer > spawnTime)
        {

            if (layer == spawnList.Length)
                layer = 0;
            for (int i = 0; i < 9; i++)
            {
                if(spawnList[layer,i] == true)
                {
                    GameObject newBlock = Instantiate(Block);
                    newBlock.GetComponent<ObstScript>().player = GameObject.FindGameObjectWithTag("Player");
                    Debug.Log("create");
                    switch(i)
                    {
                        case 0:
                            newBlock.transform.position = new Vector3(x - distance,y - distance,z);
                            break;
                        case 1:
                            newBlock.transform.position = new Vector3(x - distance, y, z);
                            break;
                        case 2:
                            newBlock.transform.position = new Vector3(x - distance, y + distance, z);
                            break;
                        case 3:
                            newBlock.transform.position = new Vector3(x, y - distance, z);
                            break;
                        case 4:
                            newBlock.transform.position = new Vector3(x, y, z);
                            break;
                        case 5:
                            newBlock.transform.position = new Vector3(x, y + distance, z);
                            break;
                        case 6:
                            newBlock.transform.position = new Vector3(x + distance, y - distance, z);
                            break;
                        case 7:
                            newBlock.transform.position = new Vector3(x + distance, y, z);
                            break;
                        case 8:
                            newBlock.transform.position = new Vector3(x + distance, y + distance, z);
                            break;
                    }
                }
            }

            layer++;
            timer = 0;
        }
    }
}
