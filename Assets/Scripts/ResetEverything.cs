using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ResetEverything : MonoBehaviour {



	// Use this for initialization
	void Start () {
		ChangeSettingsText.SetTextTo("");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ResetAll()
	{
		ScoreSaver.SaveHighScore("0");
		TutorialDoneSaver.SaveTutorialDone("false");
		ChangeSettingsText.SetTextTo("Alles wurde erfolgreich zurückgesetzt");
	}

}
