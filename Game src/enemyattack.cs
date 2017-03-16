using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class enemyattack : MonoBehaviour {

	int speed = -5;
	public Transform Zombiemanage;
	float animRate = 0.9f;
	float animOn = 0f;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine(wait());
	}

	// Update is called once per frame
	void Update ()
	{
		transform.Translate (new Vector3 (0, speed * Time.deltaTime, 0));
//		if (Zombiemanager.instance.completed == false && Zombiemanager.instance.alive == false) 
//		{
//			transform.Translate (new Vector3 (0, -((speed * Time.deltaTime) *1000), 0));
//			Destroy (gameObject);
//		}

	}
	void OnCollisionEnter2D (Collision2D col)
	{

		if ("Player" == col.gameObject.tag) 
		{
			gamemanager.instance.hit = true;
			StartCoroutine(wait());
			gamemanager.instance.hits++;
			Destroy (gameObject);
			//Zombiemanager.instance.completed = false;
			//LoadScene ("endgame");
		}
		if ("nullify" == col.gameObject.tag) 
		{
			
			Destroy (gameObject);
		}
	}
	public IEnumerator wait()
	{
		yield return new WaitForSeconds (3f);
	}
	public void LoadScene(string scenename)
	{
		SceneManager.LoadScene (scenename);
	}


}
