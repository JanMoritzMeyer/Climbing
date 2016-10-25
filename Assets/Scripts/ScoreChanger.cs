using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreChanger : MonoBehaviour {
	Text score;

	float time;

	private GUIStyle guiStyle = new GUIStyle();

	int high;

	Vector3 ScreenSize = new Vector3();

	float fontSize;
	// Use this for initialization
	void Start () 
	{
		score = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		time = time + Time.deltaTime;
		high = (int)Mathf.Floor(Player.ObjectPosition.y);
		if (time > 0.1f)
		{
			score.text = "Meter " + high + "m";
		}
	}
}