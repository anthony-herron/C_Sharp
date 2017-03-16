using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Playermanager : MonoBehaviour
{
	public float speedx;
	Animator anim;
	Rigidbody2D rb;
	public Transform shot;
	public int health = 100;
	public bool ready = true;
	public Transform lshot;
	public Transform rshot;
	//public bool burn = false;
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//LoadScene ("endgame");
		if(Input.GetKeyDown (KeyCode.UpArrow))
		{
			if (ready == true)
			{
				anim.SetInteger ("statea", 1);	
				Fire ();
				gamemanager.instance.active = true;
			}
		}
		if(Input.GetKeyUp (KeyCode.UpArrow))
		{
			anim.SetInteger ("statea", 0);	
			StartCoroutine(wait());

		}
		if(Input.GetKeyDown (KeyCode.LeftArrow))
		{
			if (ready == true)
			{
				anim.SetInteger ("statea", 1);	
				Firel ();
				gamemanager.instance.leftactive = true;
			}
		}
		if(Input.GetKeyUp (KeyCode.LeftArrow))
		{
			anim.SetInteger ("statea", 0);	
			StartCoroutine(wait());

		}
		if(Input.GetKeyDown (KeyCode.RightArrow))
		{
			if (ready == true)
			{
				anim.SetInteger ("statea", 1);	
				Firer ();
				gamemanager.instance.rightactive = true;
			}
		}
		if(Input.GetKeyUp (KeyCode.RightArrow))
		{
			anim.SetInteger ("statea", 0);	
			StartCoroutine(wait());

		}
	}
	void OnCollisionEnter2D (Collision2D col)
	{
		
		if ("eattack" == col.gameObject.tag) 
		{
				anim.SetInteger ("statea", 5);	
				StartCoroutine(Idle());
			Zombiemanager.instance.completed = true;
//				if (gamemanager.instance.palive == false)
//				{
//					Destroy (gameObject);
//					LoadScene ("endgame");
//				}
			ready = false;
		
		}
		if ("fire" == col.gameObject.tag)
		{
			anim.SetInteger ("statea", 5);	
			StartCoroutine(Idle());

			if (gamemanager.instance.palive == false)
			{
				Destroy (gameObject);
			}
			ready = false;
			gamemanager.instance.burn = true;
			//burn = true;
		}
		if ("dummy" == col.gameObject.tag) 
		{
			anim.SetInteger ("statea", 0);	
			StartCoroutine(Idle());
			ready = true;
		}

	}

	public IEnumerator wait()
	{
		yield return new WaitForSeconds (3f);
		anim.SetInteger ("State", 0);
	}

	public IEnumerator Idle()
	{
		yield return new WaitForSeconds (.3f);
		anim.SetInteger ("State", 0);
	}
	void Fire ()
	{
		Transform t = (Transform)Instantiate (shot, new Vector3 
			(transform.position.x + 1f, transform.position.y + .85f, transform.position.z), Quaternion.identity);
	}
	void Firel ()
	{
		Transform t = (Transform)Instantiate (lshot, new Vector3 
			(transform.position.x - 3f, transform.position.y + .85f, transform.position.z), Quaternion.identity);
	}
	void Firer ()
	{
		Transform t = (Transform)Instantiate (rshot, new Vector3 
			(transform.position.x + 3f, transform.position.y + .85f, transform.position.z), Quaternion.identity);
	}
	public void LoadScene(string scenename)
	{
		SceneManager.LoadScene (scenename);
	}

}
