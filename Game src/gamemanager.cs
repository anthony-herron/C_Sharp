using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{

	public static gamemanager instance;
	public int hitstaken = 0;
	public int hitstaken2 = 0;
	public int hitstaken3 = 0;
	public int hitstaken4 = 0;
	public GameObject zombie;
	public GameObject player;
	public int hits = 0;
	public bool hit = false;
	public bool palive = true;
	public bool zalive = true;
	public int level = 1;
	public bool active = false;
	public bool leftactive = false;
	public bool rightactive = false;
	public bool burn = false;
	public int totalzom = 0;
	public int zomKilled = 0;
	public bool newlevel = false;
	public bool faster = false;
	public bool fastest = false;
	public bool flash = false;
	int need = 5;
	float timer;
	// Use this for initialization
	void Start () 
	{
		instance = this;
		hits = 0;
	}
	//
	// Update is called once per frame
	void Update ()
	{
		if (hitstaken == 4) 
		{
			//Destroy (zombie);
			hitstaken = 0;
			zomKilled++;
			totalzom++;
		}
		if (hits == 3) 
		{
			Destroy (player);
			palive = false;
			timer += Time.deltaTime;	
			if (timer > 1.5) {
				LoadScene ("endgame");
			}

		//	hits = 0;
		}
		if (hitstaken4 == 3)
		{
			Destroy (zombie);
			hitstaken4 = 0;
		}
		if (zomKilled == need) 
		{
			level++;
			zomKilled = 0;
			need += 5;
			faster = true;
			if (need >= 15)
			{
				fastest = true;
				flash = true;
				faster = false;
			}
			newlevel = true;
			//Zombiemanager.instance.movespeed *= 100000 ;
		}

	}

	void OnGUI ()
	{
		GUI.Box (new Rect (Screen.width - 100, 0, 100, 50), "Total killed " + totalzom +
			"\nKilled " + zomKilled + " " +
			"\nLevel:" + level + " Hits " + (hits));

	}
	public void LoadScene(string scenename)
	{
		SceneManager.LoadScene (scenename);
	}

}
