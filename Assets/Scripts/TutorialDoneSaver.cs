using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.IO;
using UnityEngine.UI;

public class TutorialDoneSaver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static string TutorialDoneReader () {
		string isdone;
		StreamReader sr = new StreamReader(Application.persistentDataPath + "/tutorialdone.txt");
		isdone = sr.ReadLine();
		sr.Close();
		return isdone;
	}

	public static void SaveTutorialDone (string isdone)
	{
		StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/tutorialdone.txt");
		sw.Write(isdone, true, Encoding.ASCII);
		sw.Close();
	}
}
