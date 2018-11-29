using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour {

	public GameObject levelText;

	private int level;


	// Use this for initialization
	void Start () {
		level = SceneManager.GetActiveScene().buildIndex;
		levelText.GetComponent<Text>().text = "Level: " + level;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
