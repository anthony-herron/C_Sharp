using UnityEngine;
using System.Collections;

public class leftattack : MonoBehaviour {

	int speed = 3;
	public Transform Zombiemanage;
	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update ()
	{

		transform.Translate (new Vector3 (-((speed-1) * Time.deltaTime), ((speed-3) * Time.deltaTime), 0));

	}
	void OnCollisionEnter2D (Collision2D col)
	{

		if ("Enemy" == col.gameObject.tag) 
		{
			//Zombiemanage.GetInstanceID.hitstaken = 3;
			if (gamemanager.instance.hitstaken == 4) {
				Destroy (col.gameObject);
				Destroy (gameObject);
			} 
			else 
			{
				gamemanager.instance.hitstaken++;
				Destroy (gameObject);
			}
		}
		if ("nullify" == col.gameObject.tag) 
		{

			Destroy (gameObject);
		}
	}
	public IEnumerator wait()
	{
		yield return new WaitForSeconds (1f);
	}
}
