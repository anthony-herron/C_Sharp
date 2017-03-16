using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class menuctrl : MonoBehaviour 
{
	public void LoadScene(string scenename)
	{
		SceneManager.LoadScene (scenename);
	}

}
