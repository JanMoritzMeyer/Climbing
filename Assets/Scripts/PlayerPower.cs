using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerPower : MonoBehaviour {



	public static float power;

	GameObject slider;

	public static Slider sliderValue;

	public static float time;

    public Image sliderColor;

	float aufladeSpeed;

	bool isColorRed;

	bool Speedreduced;

    bool isLoading;

	// Use this for initialization
	void Start () {
		Speedreduced = false;
		aufladeSpeed = 1.0f;
		power = 10.0f;
		slider = GameObject.Find("Canvas/Slider");
		sliderValue = GetComponent<Slider>();
		sliderValue.value = sliderValue.maxValue;
		time = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		power = sliderValue.value;
		time = time + Time.deltaTime;
		Debug.Log(power);
		if (power <= 0.2f && Speedreduced == false)
		{
			Player.Geschwindigkeit /= 3.0f;
			Player.timeNeeded *= 3.0f;
            
			Speedreduced = true;
		}
		if (Player.time > 1.0f && Player.isMoving == false)
		{
			ChangeSliderValue(1.0f, Player.Geschwindigkeit * 1.5f);
            sliderColor.color = Color.Lerp(Color.red, Color.white, Mathf.PingPong(Time.time, 0.1f));
        }
		if (power > 0.3f && Speedreduced == true)
		{
			Speedreduced = false;
			Player.Geschwindigkeit *= 3.0f;
			Player.timeNeeded /= 3.0f;
            sliderColor.color = Color.white;


        }
        if (Player.isMoving == true || sliderValue.value == sliderValue.maxValue)
        {
            sliderColor.color = Color.white;
            
        }
	}

	public static void ChangeSliderValue(float Value, float speed)
	{
		sliderValue.value += Value * Time.deltaTime * speed * 1.5f;
			time = 0;
	}

}
