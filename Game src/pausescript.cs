using UnityEngine;
using System.Collections;

public class pausescript : MonoBehaviour 
{
	public bool paused;
	public GameObject pausescreen, pausepanel;
	// Use this for initialization
	void Start () 
	{
		paused = false;
		pausepanel.SetActive (false);
		pausescreen.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void onpause()
	{
//		paused = !paused;
//		if (paused)
//		{
			Time.timeScale = 0;
			pausepanel.SetActive (true);
			pausescreen.SetActive (false);
			//GUI.Box (new Rect (Screen.width, 0, 0, 50), "Paused"); 
	//	} 
//		else if (!paused) 
//		{
//			Time.timeScale = 1;
//			pausepanel.SetActive (false);
//			pausescreen.SetActive (true);
//		}
	}
	public void unpause()
	{
		Time.timeScale = 1;
		pausepanel.SetActive (false);
		pausescreen.SetActive (true);
	}

}
