using UnityEngine;
using System.Collections;

public class dummyattack : MonoBehaviour {

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

	}
	void OnCollisionEnter2D (Collision2D col)
	{

		if ("Player" == col.gameObject.tag) 
		{
			StartCoroutine(wait());
			//gamemanager.instance.hits++;
			Destroy (gameObject);
			gamemanager.instance.burn = false;
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

}
