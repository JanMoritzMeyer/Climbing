using UnityEngine;
using System.Collections;

public class ButtonClickCounter : MonoBehaviour {

	float time;

	// Use this for initialization
	void Start () {
		time = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
	}

	public void ButtonClicked ()
	{
		if (time > 0.5f)
		{
			TutorialScript.MouseClickCounter ++;
			time = 0.0f;
		}
	}
}
