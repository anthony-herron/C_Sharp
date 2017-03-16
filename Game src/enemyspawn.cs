using UnityEngine;
using System.Collections;

public class enemyspawn : MonoBehaviour 
{
	public bool isOn = true;
	public Transform zom;
	public Transform zom2;
	public Transform zom3;
	public Transform zom4;
	public Transform zom5;
	int direction = 1;
	int speed = 3;
	float lastSpawn;
	float nextSpawn = 4;
	//float nextSpawn = 10;
	public int check;
	public int zomnum;
	public int zomrange = 3;
	//public Transform ;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isOn) 
		{
			if (gamemanager.instance.faster == true) 
			{
				nextSpawn = 1;
			} 
			else if (gamemanager.instance.flash == true && gamemanager.instance.fastest == true)
			{
				nextSpawn = .6f;
			} 
			else 
			{
				nextSpawn = 1.8f;
			}
				
			if (Time.time > (lastSpawn + (nextSpawn / gamemanager.instance.level))) 
			{
				lastSpawn = Time.time + nextSpawn;
				check = Random.Range (1, 30);
				if(gamemanager.instance.level == 2)
				{
				zomrange = 5;
				}
				zomnum = Random.Range (1, zomrange);
				if (zomnum == 1) 
				{
					if (check <= 10) //middle
					{ 
						Transform es = (Transform)Instantiate (zom, new Vector3 (transform.position.x,
							             transform.position.y, ((transform.position.z * 0) - .08f)), Quaternion.identity);
						es.Translate (0, -1, 0);
					} 
					else if (check <= 20 && check > 10) //right
					{
						Transform es = (Transform)Instantiate (zom, new Vector3 (transform.position.x + 10f,
							              transform.position.y, ((transform.position.z * 0) - .08f)), Quaternion.identity);
						es.Translate (0, -1, 0);
					} 
					else if (check <= 30 && check > 20) //left
					{
						Transform es = (Transform)Instantiate (zom, new Vector3 (transform.position.x - 10f,
							              transform.position.y, ((transform.position.z * 0) - .08f)), Quaternion.identity);
						es.Translate (0, -1, 0);
					}
				}
				else if (zomnum == 2) 
				{
					if (check <= 10) 
					{
						Transform es = (Transform)Instantiate (zom2, new Vector3 (transform.position.x,
							transform.position.y, ((transform.position.z * 0) - .08f)), Quaternion.identity);
						es.Translate (0, -1, 0);
					} 
					else if (check <= 20 && check > 10) 
					{
						Transform es = (Transform)Instantiate (zom2, new Vector3 (transform.position.x + 10f,
							transform.position.y, ((transform.position.z * 0) - .08f)), Quaternion.identity);
						es.Translate (0, -1, 0);
					} 
					else if (check <= 30 && check > 20) 
					{
						Transform es = (Transform)Instantiate (zom2, new Vector3 (transform.position.x - 10f,
							transform.position.y, ((transform.position.z * 0) - .08f)), Quaternion.identity);
						es.Translate (0, -1, 0);
					}
				}
				else if (zomnum == 3) 
				{
					if (check <= 10) 
					{
						Transform es = (Transform)Instantiate (zom3, new Vector3 (transform.position.x,
							transform.position.y, ((transform.position.z * 0) - .08f)), Quaternion.identity);
						es.Translate (0, -1, 0);
					} 
					else if (check <= 20 && check > 10) 
					{
						Transform es = (Transform)Instantiate (zom3, new Vector3 (transform.position.x + 10f,
							transform.position.y, ((transform.position.z * 0) - .08f)), Quaternion.identity);
						es.Translate (0, -1, 0);
					} 
					else if (check <= 30 && check > 20) 
					{
						Transform es = (Transform)Instantiate (zom3, new Vector3 (transform.position.x - 10f,
							transform.position.y, ((transform.position.z * 0) - .08f)), Quaternion.identity);
						es.Translate (0, -1, 0);
					}
				}
				else if (zomnum >= 4) 
				{
					if (check <= 10) 
					{
						Transform es = (Transform)Instantiate (zom4, new Vector3 (transform.position.x,
							transform.position.y, ((transform.position.z * 0) - .08f)), Quaternion.identity);
						es.Translate (0, -1, 0);
					} 
					else if (check <= 20 && check > 10) 
					{
						Transform es = (Transform)Instantiate (zom4, new Vector3 (transform.position.x + 10f,
							transform.position.y, ((transform.position.z * 0) - .08f)), Quaternion.identity);
						es.Translate (0, -1, 0);
					} 
					else if (check <= 30 && check > 20) 
					{
						Transform es = (Transform)Instantiate (zom4, new Vector3 (transform.position.x - 10f,
							transform.position.y, ((transform.position.z * 0) - .08f)), Quaternion.identity);
						es.Translate (0, -1, 0);
					}
				}

			}
		}
	}
	void OnCollisionEnter (Collision col)
	{

		if ("Left" == col.gameObject.tag)
		{

			direction = 1;
			//nextSpawn = Random.Range(1.0,3.0);

		} 
		else if ("Right" == col.gameObject.tag) 
		{
			direction = -1;
			//nextSpawn = Random.Range(1.0,3.0);
		}
	}
}
