﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LastScoreLoader : MonoBehaviour {

    Text text;
    // Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        text.text = "Dein Score: " + Player.lastScore + " Meter";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
