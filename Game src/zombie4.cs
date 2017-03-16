using UnityEngine;
using System.Collections;

public class zombie4 : MonoBehaviour {

	public float speedx = 3f;
	public bool walkx;
	Animator anim;
	Rigidbody2D rb;
	bool walk;
	bool alive;
	public Transform target;
	public float speed;
	public LayerMask Default;
	private BoxCollider2D boxCollider;
	public Transform att;
	public Transform att2;
	float nextShot = 0;
	public int health = 0;
	public int movespeed = 2;
	//public int hitstaken = 0;
	//public GameManager instance = null;
	//float speed;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		walk = true;
		alive = true;
		boxCollider = GetComponent <BoxCollider2D> ();

	}

	// Update is called once per frame
	void Update ()
	{
		if (move () == true) 
		{
		} 
		else
		{
			attack ();
			StartCoroutine(wait());
		}
		if (gamemanager.instance.newlevel == true) 
		{
			Destroy (gameObject);
			gamemanager.instance.newlevel = false;
		}

	}

	void OnCollisionEnter2D (Collision2D col)
	{

		if ("attack" == col.gameObject.tag) 
		{
			health++;
			anim.SetInteger ("State", 5);
			StartCoroutine(Idle());
			if (health == 4)
			{
				gamemanager.instance.hitstaken = health;
			}
		}

	}
	public IEnumerator wait()
	{
		yield return new WaitForSeconds (3f);
	}

	public IEnumerator Idle()
	{
		yield return new WaitForSeconds (.1f);
		anim.SetInteger ("State", 0);
		gamemanager.instance.hit = false;
	}
	bool move()
	{
		bool walk = true;

		if (gamemanager.instance.faster == true) 
		{
			speed = (Time.deltaTime * 2) * movespeed;
		} 
		else if (gamemanager.instance.flash == true && gamemanager.instance.fastest == true)
		{
			speed = (Time.deltaTime * 4) * movespeed;
		}
		else 
		{
			speed = Time.deltaTime * movespeed;
		}



		if (target.position.x > transform.position.x + 3.5f) 
		{
			transform.Translate (Vector3.right * speed);
			if (target.position.y < transform.position.y - 1)
			{
				transform.Translate (Vector3.down * speed);
				return walk;
			}
			return walk;
		} 
		else if (target.position.x < transform.position.x - 5)
		{
			transform.Translate (Vector3.left * speed);
			if (target.position.y < transform.position.y - 1)
			{
				transform.Translate (Vector3.down * speed);
				return walk;
			}
			return walk;
		} 
		else if (target.position.y < transform.position.y - 1)
		{
			transform.Translate (Vector3.down * speed);
			return walk;
		}

		else 
		{
			walk = false;
			attack ();
		} 

		walkx = walk;
		return walk;
	}
	void attack()
	{
		anim.SetInteger ("State", 1);

		if (Time.time > nextShot)
		{
			StartCoroutine (Idle());
			Fire ();
			Fire2 ();
			Fire3 ();
			//StartCoroutine(wait());
			nextShot = Time.time + Random.Range (2,4);
			//gamemanager.instance.hit = true;
			StartCoroutine (Idle ());
		}
	}
	void test()
	{
		walk = false;
	}
	void Fire ()
	{
		//StartCoroutine(wait());
		Transform t = (Transform)Instantiate (att, new Vector3 
			(transform.position.x + 1f, transform.position.y + 3f, transform.position.z), Quaternion.identity);
		//StartCoroutine(wait());
		Transform n = (Transform)Instantiate (att2, new Vector3 
			(transform.position.x + 1f, transform.position.y + 6f, transform.position.z), Quaternion.identity);
	}
	void Fire2 ()
	{
		//StartCoroutine(wait());
		Transform t = (Transform)Instantiate (att, new Vector3 
			(transform.position.x + 1f, transform.position.y + 4f, transform.position.z), Quaternion.identity);
		//StartCoroutine(wait());
		Transform n = (Transform)Instantiate (att2, new Vector3 
			(transform.position.x + 1f, transform.position.y + 6f, transform.position.z), Quaternion.identity);
	}
	void Fire3 ()
	{
		//StartCoroutine(wait());
		Transform t = (Transform)Instantiate (att, new Vector3 
			(transform.position.x + 1f, transform.position.y + 6f, transform.position.z), Quaternion.identity);
		//StartCoroutine(wait());
		Transform n = (Transform)Instantiate (att2, new Vector3 
			(transform.position.x + 1f, transform.position.y + 8f, transform.position.z), Quaternion.identity);
	}
}
