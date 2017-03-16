using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour {
	float timer;
	// Use this for initialization
	void Start ()
	{
	
	}

	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;	
		if (timer > 2.5) 
		{
			LoadScene ("menu");
		}
	}

	public void LoadScene(string scenename)
	{
		SceneManager.LoadScene (scenename);
	}
}
