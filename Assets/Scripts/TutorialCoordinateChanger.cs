using UnityEngine;
using System.Collections;

public class TutorialCoordinateChanger : MonoBehaviour {

	public Vector3 mousePosition = new Vector3 ();

	public Vector3 ScreenPosition = new Vector3 ();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) ) {
			mousePosition = Input.mousePosition;
			Camera camera = GetComponent<Camera>();
			ScreenPosition = camera.ScreenToWorldPoint(mousePosition);
			TutorialScript.screenx = (int)Mathf.Floor(ScreenPosition.x);
			TutorialScript.screeny = (int)Mathf.Floor(ScreenPosition.y);
			TutorialScript.screenx = Mathf.Abs(TutorialScript.screenx);
			TutorialScript.screeny = Mathf.Abs(TutorialScript.screeny);
		}
	}
}
