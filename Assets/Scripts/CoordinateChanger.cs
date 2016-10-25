using UnityEngine;
using System.Collections;

public class CoordinateChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Setzt die WorldMouseKoordinaten in ScreenKoordinaten um && Player.isMoving == false
        if (Input.GetMouseButtonDown (0) ) {
            Player.mousePosition = Input.mousePosition;
            Camera camera = GetComponent<Camera>();
			Player.Screenposition = camera.ScreenToWorldPoint(Player.mousePosition);
			Player.mouseclicked = true;
            Player.screenx = (int)Mathf.Floor(Player.Screenposition.x);
            Player.screeny = (int)Mathf.Floor(Player.Screenposition.y);
        }
	}
}
