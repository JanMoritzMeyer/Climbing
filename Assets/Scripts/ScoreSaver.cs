using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using System.Text;
using System;

public class ScoreSaver : MonoBehaviour {

    public static string score;

	public static Text highscore;

	public static bool isWriting;

	// Use this for initialization
	void Start () {
		highscore = GetComponent<Text>();
		highscore.text = ReadHighScore();
	}
	void Update()
    {
		if(isWriting == true)
		{
			highscore.text = ReadHighScore();
		}
		Debug.Log(Application.persistentDataPath);
    }
	public static string ReadHighScore () {
        //string score;
		//int scoreInt;
		StreamReader sr = new StreamReader(Application.persistentDataPath + "/score.txt");
		score = sr.ReadLine();
		return "HighScore: " + score + " Meter";
		//sr.Close();
	}
      
	public static void SaveHighScore (string meter)
	{
        int scoreInt;
        int meterInt;
		scoreInt = Convert.ToInt32(score);
		meterInt = Convert.ToInt32(meter);
		Debug.Log(meterInt);
		Debug.Log(scoreInt);
		if (scoreInt < meterInt || meter == "0")
        {
			StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/score.txt");
            sw.Write(meter, true, Encoding.ASCII);
            sw.Close();
        }
	}
}
