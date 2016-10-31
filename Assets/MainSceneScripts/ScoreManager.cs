using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    private float score;

    public void blockDestroy()
    {
        score = score + 1;
    }

    public void blockCollision()
    {
        score = score - 1.25f;
    }

	// Use this for initialization
	void Start () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperRight;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        string text = "Score : " + score;
        GUI.Label(rect, text, style);
    }
}
