using UnityEngine;
using System.Collections;

public class handleSpawner : MonoBehaviour {

	Vector3 lastCreatedHandlePositon = new Vector3();

	Vector3 lastCreatedHandlePositon2 = new Vector3();

	int fields = 10;

	int randomNumber = 7;

	float timeUntilNextHandle = 0.1f;

	float time = 0;

	float x = 0.5f;

	float y = 0;

	int lastRandomNumber;

	int lowestnumber = 0;

	int highestnumber = 3;

	float lasthandlex;

	float lasthandley;

	float lasthandlex2;

	float lasthandley2;

	int createdHandles;

	public Transform handle;
   


	    // Use this for initialization
	void Start () 
	{
		randomNumber = (Random.Range (lowestnumber, highestnumber));
		lowestnumber = fields / 2 * -1;
		highestnumber = fields / 2;
		Instantiate(handle, new Vector3(randomNumber + 0.5f, 1.5f, 1), Quaternion.identity);
		Player.Griffe[(int)randomNumber,1] = true;
		lastCreatedHandlePositon = new Vector3 (randomNumber + 0.5f, 1.5f, 1);
		lowestnumber = 1;
		highestnumber = 5;

	}
	
	// Update is called once per frame
	void Update () {
		time = time + Time.deltaTime;
		lastRandomNumber = randomNumber;
		if (time > timeUntilNextHandle || createdHandles < 20)
		{
			randomNumber = (Random.Range (lowestnumber, highestnumber));
			for (int i = 0; i < 3; i++)
			{
				
				if (randomNumber == lastRandomNumber)
				{
					randomNumber = (Random.Range ( lowestnumber, highestnumber));
				}
			}
			//linksoben
			if (randomNumber == 1 && lastCreatedHandlePositon.x != 0.5f) 
			{
				x = lastCreatedHandlePositon.x - 1.0f;
				y = lastCreatedHandlePositon.y + 1.0f;
				Instantiate(handle, new Vector3(x, y, 1), Quaternion.identity);
				lastCreatedHandlePositon = new Vector3 (x, y, 0);
				time = 0.0f;
				createdHandles ++;
			}
			//rechtsoben
			else if (randomNumber == 2 && lastCreatedHandlePositon.x != 5.5f)
			{
				x = lastCreatedHandlePositon.x + 1.0f;
				y = lastCreatedHandlePositon.y + 1.0f;
				Instantiate(handle, new Vector3(x, y, 1), Quaternion.identity);
				lastCreatedHandlePositon = new Vector3 (x, y, 0);
				time = 0.0f;
				createdHandles ++;
			}
			//rechts ohne Fortsetzung des Tracks
			else if ( randomNumber == 3 && lastCreatedHandlePositon.x != 5.5f)
			{
				x = lastCreatedHandlePositon.x + 1.0f;
				y = lastCreatedHandlePositon.y + 1.0f;
				Instantiate(handle, new Vector3(x, y, 1), Quaternion.identity);
				lastCreatedHandlePositon2 = new Vector3 (x, y, 0);
				time = 0.0f;
				createdHandles ++;

			}
			//links ohne Fortsetzung des Tracks
			else if ( randomNumber == 4 && lastCreatedHandlePositon.x != 0.5f)
			{
				x = lastCreatedHandlePositon.x - 1.0f;
				y = lastCreatedHandlePositon.y + 1.0f;
				Instantiate(handle, new Vector3(x, y, 1), Quaternion.identity);
				lastCreatedHandlePositon2 = new Vector3 (x, y, 0);
				time = 0.0f;
				createdHandles ++;

			}
			//eintragen der Griffe in den Array
			lasthandlex2 = Mathf.Floor(lastCreatedHandlePositon2.x);
			lasthandley2 = Mathf.Floor(lastCreatedHandlePositon2.y);
			lasthandlex = Mathf.Floor(lastCreatedHandlePositon.x);
			lasthandley = Mathf.Floor(lastCreatedHandlePositon.y);
			Player.Griffe[(int)lasthandlex, (int)lasthandley] = true;
			Player.Griffe[(int)lasthandlex2, (int)lasthandley2] = true;
			time = 0.0f;
			//Debug.Log(time);
		}
	}
}
