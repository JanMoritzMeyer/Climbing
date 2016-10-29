using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {

	Vector3 CameraStartPosition = new Vector3 ();

	public static Vector3 CameraPosition = new Vector3 ();

	float difficulty = 1.5f;

    float CameraPositiony;

	float time;

	float time2;

	float timeUntilMoving = 5.0f; 

	Transform transformEnergydart;

	GameObject Energydart;

	Vector3 dartposition = new Vector3();

	// Use this for initialization
	void Start () {
		CameraStartPosition = transform.position;
		difficulty = 1.5f;
		timeUntilMoving = 5.0f;
		Energydart = GameObject.Find("powerdart");
		transformEnergydart = Energydart.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		time2 += Time.deltaTime;
		time = time + Time.deltaTime;
        CameraPosition = transform.position;
        CameraPositiony = Mathf.Floor(CameraPosition.y);
        Debug.Log(Player.HomePosition);
		if (Player.ObjectPosition.y > 5.0f)
		{
			timeUntilMoving = 0.0f;
		}

		if (time > timeUntilMoving && Player.ObjectPosition.y > 1.5f)
		{
			CameraPosition = transform.position;
			dartposition = GameObject.Find("powerdart").transform.position;
			CameraPosition.y = CameraPosition.y + difficulty * Time.deltaTime;
			dartposition.y = dartposition.y + difficulty * Time.deltaTime;
			GameObject.Find("powerdart").transform.position = dartposition;
			transform.position = CameraPosition;

        }
        if (time > timeUntilMoving + 1.0f && Player.ObjectPosition.y > 3.5f && transform.position.y > 7.0f)
        {
            Player.Griffe[0, (int)CameraPositiony - 7] = false;
            Player.Griffe[1, (int)CameraPositiony - 7] = false;
            Player.Griffe[2, (int)CameraPositiony - 7] = false;
            Player.Griffe[3, (int)CameraPositiony - 7] = false;
            Player.Griffe[4, (int)CameraPositiony - 7] = false;
            Player.Griffe[5, (int)CameraPositiony - 7] = false;
        }
        if (time > timeUntilMoving * 2 && Player.usingHomeVector == false)
		{
			Player.HomePosition.y = Player.HomePosition.y + difficulty * Time.deltaTime;
		}
        if (CameraPosition.y > 50 && CameraPosition.y < 75)
        {
            difficulty = 2;
        }
        else if(CameraPosition.y > 75 && CameraPosition.y < 100)
        {
            difficulty = 1.5f;
        }
		else if( CameraPosition.y > 100 && CameraPosition.y < 200)
        {
            difficulty = 2.5f;
        }
		else if ( CameraPosition.y > 200)
		{
            difficulty = 3.0f;
		}
	}
}
