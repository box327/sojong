using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Text t;
    public void buttonTest()
    {
        if (t.text == "ON")
        {
            t.text = "OFF";
        }
        else
        {
            t.text = "ON";
        }
    }

    public void startGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("main_game_scene");
    }
}
