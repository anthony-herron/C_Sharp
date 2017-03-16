using UnityEngine;
using System.Collections;

public class Fireattack : MonoBehaviour 
{
	int speed = -5;
	public Transform Zombiemanage;
	float animRate = 0.9f;
	float animOn = 0f;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (new Vector3 (0, speed * Time.deltaTime, 0));
		if (gamemanager.instance.burn == false && gamemanager.instance.zalive == false) 
		{
			Destroy (gameObject);
		}
	}
	void OnCollisionEnter2D (Collision2D col)
	{

		if ("Player" == col.gameObject.tag) 
		{
			gamemanager.instance.hit = true;
			StartCoroutine(wait());
			gamemanager.instance.hits++;
			Destroy (gameObject);
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
