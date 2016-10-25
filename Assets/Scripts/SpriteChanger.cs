using UnityEngine;
using System.Collections;

public class SpriteChanger : MonoBehaviour {
	public static SpriteRenderer sr;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.ObjectPosition.y == 0.5)
		{
			LoadKliffStand();
		}
	}
	public static void LoadKliffStand ()
	{
		if (Player.ObjectPosition.y != 0.5)
		{
			sr.flipX = false;
			sr.sprite = Resources.Load<Sprite>("KliffStand");
		}
	}

	public static void LoadKliffHanging ()
	{
		if (Player.ObjectPosition.y != 0.5)
		{
			sr.flipX = false;
			sr.sprite = Resources.Load<Sprite>("KliffHanging");
		}
	}

	public static void LoadKliffClimbingLeft ()
	{
		sr.flipX = true;
		sr.sprite = Resources.Load<Sprite>("KliffClimbing");
	}

	public static void LoadKliffClimbingRight ()
	{
		sr.flipX = false;
		sr.sprite = Resources.Load<Sprite>("KliffClimbing");
	}
}
