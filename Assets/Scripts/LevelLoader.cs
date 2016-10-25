using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
	bool levelLoaded = false;

	// Use this for initialization
	void Start () {
		levelLoaded = false;
		Debug.Log(TutorialDoneSaver.TutorialDoneReader());

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(Application.persistentDataPath);
	}

	public static void LoadLevel1() {
		SceneManager.LoadScene (2);
	}
	public void LoadLevel_1() {
		SceneManager.LoadScene (2);
	}
	public static void LoadDieScreen(){
		SceneManager.LoadScene (3);
	}
    public void Loadmenue()
    {
        SceneManager.LoadScene(1);
    }
	public static void Loadmenue1()
	{
		SceneManager.LoadScene(1);
	}
	public static void LoadTutorial1()
	{
		SceneManager.LoadScene(0);
		TutorialDoneSaver.SaveTutorialDone("false");
	}
	public void LoadTutorial()
	{
		SceneManager.LoadScene(0);
		TutorialDoneSaver.SaveTutorialDone("false");
	}
	public void LoadSettings()
	{
		SceneManager.LoadScene(4);
	}
}
