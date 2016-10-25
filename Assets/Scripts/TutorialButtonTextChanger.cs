using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialButtonTextChanger : MonoBehaviour {
	public static Text ButtonText;
	// Use this for initialization
	void Start () {
		ButtonText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public static void SetTutorialButtonText (string nexttext)
	{
		ButtonText.text = nexttext;
	}
}
