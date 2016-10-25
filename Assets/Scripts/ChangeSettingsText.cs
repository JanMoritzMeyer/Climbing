using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeSettingsText : MonoBehaviour {
	public static Text textobject;
	// Use this for initialization
	void Start () {
		textobject = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public static void SetTextTo(string text)
	{
		textobject.text = text;
	}
}
