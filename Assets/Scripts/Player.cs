using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {



	public static bool[,] Griffe = new bool[900,900];


	public static float timeNeeded = 0.33333f;
	public static float Geschwindigkeit = 3.0f;
	public static float time = 10.0f;
	float moveHorizontal = 0;
	float moveVertical = 0;
	public static int screenx = -2;
	public static int screeny = -6;
	public static bool mouseclicked = false;
    public string high;
	//decimal screenxd = 0;
	//decimal screenyd = 0;
	//bool right = false;
	enum directions 
	{
		none,
		leftup,
		leftdown,
		rightup,
		rightdown,
		up,
		down,
		left,
		right,
		gohome
	}

	directions moveDirection;

	//GameObject handle2 = new GameObject handle (1);

	//int Playerspeed = 10;

	//float step = 1000 * Time.deltaTime;

	public static Vector3 mousePosition = new Vector3 (0.0f, 0.0f, 0.0f);

	public static Vector3 plusone = new Vector3 (1.0f, 1.0f, 0.0f);

	public static Vector3 minusone = new Vector3 (-1.0f, -1.0f, 0.0f);

    public static Vector3 Screenposition = new Vector3(1.5f, 0.5f, 0.0f);

	public static Vector3 HomePosition = new Vector3 (1.5f, 0.5f, 0.0f);

	Vector3 DistanzToHomeVector = new Vector3 (0.0f, 0.0f, 0.0f);

	public static Vector3 ObjectPosition = new Vector3(1.5f, 0.5f, 0.0f);

    public static int lastScore;

	public static bool usingHomeVector = false;

	bool movingtoHome = false;

	//Vector3 Griffposition = new Vector3();

	Vector3 GreifDistanz = new Vector3();

	public static bool isMoving = false;

    int highInt;

	double positionx = 1.5f;

	Vector3 ObjectTarget = new Vector3 (1.5f, 0.5f);

	float objectTargetx;

	float objectTargety;

	bool awayfromHome = true;

	//float DistanzToHome = 0;

	float DistanzToHomeX = 0;

	float DistanzToHomeY = 0;
	 
	double positiony = 0.5f;

	float time2 = 10.0f;

	bool clickRecognized;

    public static float maxDistanceDelta = 100.0f;

    public static Vector3 LocalMousePosition = new Vector3(screenx, screeny, 0.0f);


	void Start(){
		//Definiert wo sich die Griffe befinden
		/*for (int i = 0; i < 18; i++)
		{
			Griffposition = GameObject.Find ("handle" + " (" + i + ")").transform.position;
			Griffposition.x = (int)Mathf.Floor(Griffposition.x) +6;
			Griffposition.y = (int)Mathf.Floor (Griffposition.y) +8;
			Griffe[(int)Griffposition.x, (int)Griffposition.y] = true;
			Debug.Log("Initalised" + i);
		}*/
		Geschwindigkeit = 3.0f;
		timeNeeded = 1.0f / Geschwindigkeit;
		screenx = 1;
		screeny = 0;

	}

	void Update()
	{

        Debug.Log(isMoving);
		time2 = time2 + Time.deltaTime;
        //Gibt an das die unteren Griffe, betreten werden dürfen
        Griffe[0,0] = true;
        Griffe[1,0] = true;
		Griffe[2,0] = true;
		Griffe[3,0] = true;
		Griffe[4,0] = true;
		Griffe[5,0] = true;
		Griffe[6,0] = true;
		

		ObjectPosition = transform.position;

		DistanzToHomeY = ObjectPosition.y - HomePosition.y;

		DistanzToHomeX = ObjectPosition.x - HomePosition.x;

		//Debug.Log (ObjectPosition);
		//Debug.Log (HomePosition);

		if (usingHomeVector == false) {
			DistanzToHomeVector = new Vector3 (DistanzToHomeX, DistanzToHomeY, 0.0f);

			DistanzToHomeVector = DistanzToHomeVector * -Geschwindigkeit;
		}
		//Debug.Log (usingHomeVector);



		//DistanzToHomeX = Mathf.Abs (DistanzToHomeX);

		//DistanzToHomeY = Mathf.Abs (DistanzToHomeY);

		//DistanzToHome = DistanzToHomeX + DistanzToHomeY;

		LocalMousePosition.x = screenx + 0.5f;

        LocalMousePosition.y = screeny + 0.5f;

		//Vector3 Richtung = LocalMousePosition;
       
        //Vector3 startposition = new Vector3 (-1.0f, -5.0f, 0.0f);

		Rigidbody2D rigid = GetComponent (typeof(Rigidbody2D)) as Rigidbody2D;
		

		time = time + Time.deltaTime;
		//Debug.Log (time);
		//Debug.Log (right);
		//Debug.Log (Input.GetAxis ("Horizontal"));
		Debug.Log(HomePosition);
		Debug.Log(DistanzToHomeVector);
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rigid.velocity = movement;
		//Debug.Log (movement);
		/*Debug.Log (mousePosition);
		Debug.Log (Screenposition);
		Debug.Log (screenx);
		Debug.Log (screeny);*/
        //Debug.Log(ObjectPosition);
        //Debug.Log(LocalMousePosition);

		/*if (Input.GetMouseButtonDown (0)) 
		{
			//Camera camera = GetComponent();
			//mousePosition = Input.mousePosition;
			//Screenposition = camera.ScreenToWorldPoint(mousePosition);
			screenx = (int)Mathf.Floor(Screenposition.x);
			screeny = (int)Mathf.Floor(Screenposition.y);
			mouseclicked = false;
        }*/

		ObjectPosition = transform.position;
		
		//Debug.Log (screenx + 6);
		//Debug.Log (screeny + 8);

		GreifDistanz = LocalMousePosition - ObjectPosition;
		//&& time > 0.1f
		if (mouseclicked == true && usingHomeVector == false && PlayerPower.sliderValue.value > 0.3f)
        {
			
            if (GreifDistanz.x <= -1.0f && GreifDistanz.y <= -1.0f) 
		    {
                isMoving = true;
                moveDirection = directions.leftdown;
			    time = 0.0f;
			    mouseclicked = false;
			    ObjectTarget = new Vector3(ObjectPosition.x -1.0f, ObjectPosition.y -1.0f, ObjectPosition.z);
				awayfromHome = false;
				PlayerPower.ChangeSliderValue(-0.1f, Geschwindigkeit);

			} 
		    else if (GreifDistanz.x >= 1.0f && GreifDistanz.y >= 1.0f) 
		    {
			    moveDirection = directions.rightup;
                isMoving = true;
                time = 0.0f;
			    mouseclicked = false;
			    ObjectTarget = new Vector3(ObjectPosition.x +1.0f, ObjectPosition.y +1.0f, ObjectPosition.z);
				awayfromHome = false;
		    } 
		    else if (GreifDistanz.x >= 1.0f && GreifDistanz.y == 0) 
		    {
			    moveDirection = directions.right;
                isMoving = true;
                time = 0.0f;
			    mouseclicked = false;
			    ObjectTarget = new Vector3(ObjectPosition.x +1.0f, ObjectPosition.y +0.0f, ObjectPosition.z);
				awayfromHome = false;
		    } 
		    else if (GreifDistanz.x <= -1.0f && GreifDistanz.y == 0) 
		    {
			    moveDirection = directions.left;
                isMoving = true;
                time = 0.0f;
			    mouseclicked = false;
			    ObjectTarget = new Vector3(ObjectPosition.x -1.0f, ObjectPosition.y +0.0f, ObjectPosition.z);
				awayfromHome = false;

		    } 
		    else if (GreifDistanz.x == 0 && GreifDistanz.y >= 1.0f) 
		    {
			    moveDirection = directions.up;
			    time = 0.0f;
                isMoving = true;
                mouseclicked = false;
			    ObjectTarget = new Vector3(ObjectPosition.x +0.0f, ObjectPosition.y +1.0f, ObjectPosition.z);
				awayfromHome = false;
		    } 
		    else if (GreifDistanz.x == 0.0f && GreifDistanz.y <= -1.0f) 
		    {
			    moveDirection = directions.down;
			    time = 0.0f;
                isMoving = true;
                mouseclicked = false;
			    ObjectTarget = new Vector3(ObjectPosition.x +0.0f, ObjectPosition.y -1.0f, ObjectPosition.z);
				awayfromHome = false;
		    }
		    else if (GreifDistanz.x <= -1.0f && GreifDistanz.y >= 1.0f) 
		    {
			    moveDirection = directions.leftup;
			    time = 0.0f;
			    mouseclicked = false;
                isMoving = true;
			    ObjectTarget = new Vector3(ObjectPosition.x -1.0f, ObjectPosition.y +1.0f, ObjectPosition.z);
				awayfromHome = false;
		    } 
		    else if (GreifDistanz.x >= 1.0f && GreifDistanz.y <= -1.0f) 
		    {
			    moveDirection = directions.rightdown;
                isMoving = true;
			    time = 0.0f;
			    mouseclicked = false;
			    ObjectTarget = new Vector3(ObjectPosition.x +1.0f, ObjectPosition.y -1.0f, ObjectPosition.z);
				awayfromHome = false;
		    } 

		} 
	//else if (Griffe [screenx + 6, screeny + 8] == false) {
			//transform.position = new Vector3 (-1.5f, -5.5f, 0.0f);
		//Griffe [screenx + 6, screeny + 8] == true
		//}


		//if (time > 0.4f)

		if (moveDirection == directions.leftdown && time < timeNeeded) {
			transform.position += new Vector3 (-Geschwindigkeit, -Geschwindigkeit, 0.0f) * Time.deltaTime;
			PlayerPower.ChangeSliderValue(-0.1f, Geschwindigkeit);
		SpriteChanger.LoadKliffClimbingLeft();
	} 
		else if (moveDirection == directions.rightup && time < timeNeeded) {
			transform.position += new Vector3 (Geschwindigkeit, Geschwindigkeit, 0.0f) * Time.deltaTime;
			PlayerPower.ChangeSliderValue(-0.1f, Geschwindigkeit);
		SpriteChanger.LoadKliffClimbingRight();
	} 
		else if (moveDirection == directions.leftup && time < timeNeeded) {
			transform.position += new Vector3 (-Geschwindigkeit, Geschwindigkeit, 0.0f) * Time.deltaTime;
			PlayerPower.ChangeSliderValue(-0.1f, Geschwindigkeit);
		SpriteChanger.LoadKliffClimbingLeft();
	} 
		else if (moveDirection == directions.rightdown && time < timeNeeded) {
			transform.position += new Vector3 (Geschwindigkeit, -Geschwindigkeit, 0.0f) * Time.deltaTime;
			PlayerPower.ChangeSliderValue(-0.1f, Geschwindigkeit);
		SpriteChanger.LoadKliffClimbingRight();
	} 
		else if (moveDirection == directions.left && time < timeNeeded) {
			transform.position += new Vector3 (-Geschwindigkeit, 0.0f) * Time.deltaTime;
			PlayerPower.ChangeSliderValue(-0.1f, Geschwindigkeit);
		SpriteChanger.LoadKliffHanging();

	}
		else if (moveDirection == directions.right && time < timeNeeded)
	{
			transform.position += new Vector3 (Geschwindigkeit, 0.0f) * Time.deltaTime;
			PlayerPower.ChangeSliderValue(-0.1f, Geschwindigkeit);
		SpriteChanger.LoadKliffHanging();
	}
		else if (moveDirection == directions.up && time < timeNeeded)
	{
			transform.position += new Vector3 (0.0f, Geschwindigkeit) * Time.deltaTime;
			PlayerPower.ChangeSliderValue(-0.1f, Geschwindigkeit);
		SpriteChanger.LoadKliffHanging();
	}
		else if (moveDirection == directions.down && time < timeNeeded)
	{
			transform.position += new Vector3 (0.0f, Geschwindigkeit) * Time.deltaTime;
			PlayerPower.ChangeSliderValue(-0.1f, Geschwindigkeit);
		SpriteChanger.LoadKliffHanging();
	}
		else if (time > timeNeeded) 
	{
		positionx = ObjectTarget.x;
		positiony = ObjectTarget.y;
		transform.position = new Vector3 ((float)positionx, (float)positiony, 0.0f);
		transform.rotation = Quaternion.Euler(0, 0, 0);
		ObjectPosition = transform.position;
		SpriteChanger.LoadKliffHanging();
		if (ObjectPosition == LocalMousePosition && Griffe [screenx, screeny] == true) 
		{
			//empty
		}
	}
		if (time > timeNeeded)
		{
			transform.position = new Vector3(Mathf.Floor(transform.position.x) + 0.5f, Mathf.Floor(transform.position.y) + 0.5f);

		}
		if (time > timeNeeded && transform.position != HomePosition ) 
	{
            isMoving = false;
			float x = Mathf.Floor(ObjectTarget.x);
			float y = Mathf.Floor(ObjectTarget.y);
			if (ObjectPosition != ObjectTarget || Griffe [(int) x, (int) y] == false && isMoving == false) 
		{
			Debug.Log(ObjectPosition);
			Debug.Log(ObjectTarget);
			Debug.Log(Griffe [(int)ObjectTarget.x, (int)ObjectTarget.y]);
			Debug.Log(ObjectPosition != ObjectTarget);
			moveDirection = directions.gohome;
            highInt = (int)Mathf.Floor(transform.position.y);
            string high = highInt.ToString();
            ScoreSaver.SaveHighScore(high);
            lastScore = highInt;
            HomePosition.y = Mathf.Floor(HomePosition.y) + 0.5f;
            HomePosition.y = Mathf.Floor(HomePosition.y) + 0.5f;
			ObjectTarget = HomePosition;
			time2 = 0;
			positionx = Mathf.Floor (transform.position.x) + 0.5;
			positiony = Mathf.Floor (transform.position.y) + 0.5;
			transform.position = new Vector3 ((float)positionx, (float)positiony, 0.0f);
			isMoving = true;
		}
	}

	if (moveDirection == directions.gohome) 
	{
			if (time2 < timeNeeded && isMoving == true) 
		{
			usingHomeVector = true;
			transform.position += DistanzToHomeVector * Time.deltaTime;
			transform.Rotate(new Vector3(0.0f, 0.0f, 360.0f) * Time.deltaTime);
			//Debug.Log ("ICH IN HIER");	
		} 
		else //if (time > 0.5f)
		{
		moveDirection = directions.none;
		usingHomeVector = false;
		transform.rotation = Quaternion.Euler(0, 0, 0);
        Array.Clear(Griffe, 0, Griffe.Length);
        HomePosition = new Vector3(1.5f, 0.5f, 0.0f);
		time = 10.0f;
		time2 = 10.0f;
		isMoving = false;
		usingHomeVector = false;
		LevelLoader.LoadDieScreen();
		//Debug.Log ("HALLO123");
		//Debug.Log (time);
		//Debug.Log (usingHomeVector);
		}
	}
	
	else if (moveDirection == directions.none)
	{
		//do nothing
	}
	
		if(time2 > timeNeeded)
		{
			movingtoHome = false;
		}
		Debug.Log(moveDirection);
		Debug.Log(time);
		Debug.Log(time2);
		Debug.Log(isMoving);
		

}



	//transform.position += Richtung * Geschwindigkeit
		//* Time.deltaTime;

	





/*GreifDistanz == new Vector3 (1.0f, 1.0f, 0.0f)
GreifDistanz == new Vector3 (-1.0f, 1.0f, 0.0f)
GreifDistanz == new Vector3 (1.0f, -1.0f, 0.0f)*/
}
