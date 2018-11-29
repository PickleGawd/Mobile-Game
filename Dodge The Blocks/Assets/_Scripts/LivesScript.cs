using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesScript : MonoBehaviour {

	int lives;

	void Start()
	{
		lives = PlayerPrefs.GetInt("Lives");
		gameObject.GetComponent<Text>().text = "Lives: " + lives;
	}
}
