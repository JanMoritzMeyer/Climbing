using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialScript : MonoBehaviour {

	Text tutorialtext;

	public static float MouseClickCounter = 0;

	public Transform player;

	public Transform arrows;

	public Transform handlePrefab;

	public GameObject PlayerClone;

	public GameObject arrowin8directions;

	GameObject fingertab;

	GameObject meter;

	GameObject handleObject;

	GameObject arrowtoEnergyBar;

	GameObject EnergyBar;

	public Transform arrowtoEnergyBarTransform;

	bool createdObjects = false;

	bool createdArrows;

	public static float screenx;

	public static float screeny;

	bool PlayerClicked;

	GameObject Button;

	Vector3 MousePosition = new Vector3();

	bool levelLoaded = false;

	bool createdHandle = false;

	bool handleClicked;

	bool createdEnergyObjects;

	bool energyBarClicked;

	bool energyBarClicked2;

	float time;

	// Use this for initialization
	void Start () {
		tutorialtext = GetComponent<Text>();
		GameObject.Find("Canvas/Text").GetComponent<Transform>().position += new Vector3 (0.0f, -200.0f);
		tutorialtext.text = "Klicke auf Fortfahren";
		MouseClickCounter = 0;
		createdObjects = false;
		createdArrows = false;
		createdHandle = false;
		PlayerClicked = false;
		handleClicked = false;
		energyBarClicked = false;
		energyBarClicked2 = false;
		createdEnergyObjects = false;
		time = 0.0f;
		meter = GameObject.Find("Canvas/Meter");
		meter.SetActive(false);
		fingertab = GameObject.Find("fingertap");
		fingertab.SetActive(false);
		EnergyBar = GameObject.Find("Canvas/Slider");
		Button = GameObject.Find ("Canvas/Button");
		EnergyBar.SetActive(false);
		TutorialButtonTextChanger.SetTutorialButtonText("Fortfahren");
		if (TutorialDoneSaver.TutorialDoneReader() == "true" && levelLoaded == false)
		{
			LevelLoader.Loadmenue1();
			levelLoaded = true;
		}

	}
	
	// Update is called once per frame
	void Update () {
		time =+ Time.deltaTime;
		MousePosition = new Vector3(screenx, screeny);
		if (MouseClickCounter == 1 || MouseClickCounter == 3 || MouseClickCounter == 4)
		{
			if (createdObjects == false)
			{
				GameObject.Find("Canvas/Text").GetComponent<Transform>().position += new Vector3 (0.0f, +200.0f);
				PlayerClone = Instantiate(player, new Vector3(0.1f, 0.0f, 0.0f), Quaternion.identity) as GameObject;
				createdObjects = true;
				Button.SetActive (false);
				tutorialtext.text = "Klicke Kliff(dein Spieler)";
				time = 0.0f;
			}
			if(MousePosition == new Vector3(0.0f, 0.0f) || MousePosition == new Vector3(1.0f, 0.0f) || MousePosition == new Vector3(0.0f, 1.0f))
			{
				if(PlayerClicked == false && MouseClickCounter == 1)
				{
					MouseClickCounter ++;
					PlayerClicked = true;
					time = 0.0f;
				}
			}
			if(MousePosition == new Vector3(0.0f, 0.0f) || MousePosition == new Vector3(1.0f, 0.0f) || MousePosition == new Vector3(0.0f, 1.0f) || MousePosition == new Vector3(1.0f, 1.0f))
			{
				if(handleClicked == false && MouseClickCounter == 3)
				{
					MouseClickCounter ++;
					handleClicked = true;
					//time = 0.0f;
				}
			}
			if(MousePosition == new Vector3(2.0f, 5.0f) || MousePosition == new Vector3(1.0f, 5.0f) || MousePosition == new Vector3(0.0f, 5.0f))
			{
				if(energyBarClicked == false && MouseClickCounter == 4 && handleClicked == true)
				{
					MouseClickCounter ++;
					handleClicked = false;
					energyBarClicked = true;
					time = 0.0f;
				}
			}
		}
		Debug.Log(screenx);
		Debug.Log(screeny);
		Debug.Log(MouseClickCounter);
		Debug.Log(PlayerClicked);
		Debug.Log(handleClicked);
		Debug.Log(MousePosition);
		if (MouseClickCounter == 2 && createdArrows == false)
		{
			Button.SetActive (true);
			tutorialtext.text = "Kliff kann sich jeweils einen Block in je 8Richtungen bewegen";
			arrowin8directions = Instantiate(arrows, new Vector3(0.1f, -0.25f, 0.0f), Quaternion.identity) as GameObject;	
			createdArrows = true;

		}
		if (MouseClickCounter == 3 && createdHandle == false)
		{
			if (createdArrows == true)
			{
				arrowin8directions = GameObject.Find("arrowsin8directions(Clone)");
				PlayerClone = GameObject.Find("player(Clone)");
				arrowin8directions.SetActive (false);
				PlayerClone.SetActive (false);
				createdArrows = false;
			}
			Button.SetActive (false);
			tutorialtext.text = "Dies sind die Griffe, klicke auf die Griffe um dich zu bewegen";
			fingertab.SetActive(true);
			handleObject = Instantiate(handlePrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity) as GameObject;
			createdHandle = true;
		}
		if (MouseClickCounter == 4 && createdEnergyObjects == false)
		{
			//Button.SetActive (true);
			fingertab.GetComponent<Transform>().position = new Vector3(0.0f, 0.0f);
			handleObject = GameObject.Find("handlePrefab(Clone)");
			tutorialtext.text = "Außerdem darfst du nie deine Energie aus dem Auge lassen. Drücke auf die EnergieLeiste";
			handleObject.SetActive(false);
			fingertab.SetActive(false);
			arrowtoEnergyBar = Instantiate(arrowtoEnergyBarTransform, new Vector3(0.4f, -4.5f), Quaternion.identity) as GameObject;
			EnergyBar.SetActive(true);
			createdEnergyObjects = true;
		}
		if (MouseClickCounter == 5 && createdEnergyObjects == true)
		{
			Button.SetActive(true);
			//meter.SetActive(true);
			arrowtoEnergyBar = GameObject.Find("arrowToEnergyBarPrefab(Clone)");
			arrowtoEnergyBar.SetActive(false);
			EnergyBar.SetActive(false);
			createdEnergyObjects = false;
			GameObject.Find("Canvas/Text").GetComponent<Transform>().position += new Vector3 (0.0f, -200.0f);
			tutorialtext.text = "Los Gehts";
			TutorialButtonTextChanger.SetTutorialButtonText("Los Gehts");
		}
		if (MouseClickCounter >= 6)
		{
			TutorialDoneSaver.SaveTutorialDone("true");
			LevelLoader.LoadLevel1();
		}
	
	
	}
}
/*if (createdObjects == true){
				GameObject.Find ("arrowsin8directions(Clone)").SetActive (false);
				GameObject.Find ("player(Clone)").SetActive (false);
				createdObjects == false;
			}*/