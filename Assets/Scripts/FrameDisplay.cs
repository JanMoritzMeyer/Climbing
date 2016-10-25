using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class FrameDisplay : MonoBehaviour {
    Text FrameText;

    int FramesPerSecond;

    float FramesPerSecondFloat;

    float time = 0;

	float fontSize;

	private GUIStyle guiStyle = new GUIStyle();

	Vector3 ScreenSize = new Vector3();
	// Use this for initialization
	void Start () {
        FrameText = GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
		time = time + Time.deltaTime;
        if (time > 0.1f)
        { 
        FramesPerSecondFloat = 1.0f / Time.deltaTime;
        FramesPerSecond = (int)Mathf.Floor(FramesPerSecondFloat);
        FrameText.text = "Frames:" + FramesPerSecond;
        time = 0.0f;
        }
    }
}
