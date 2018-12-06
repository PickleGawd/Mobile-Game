using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour {

	private void Awake()
	{

	}

	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Text>().text = "Coins: " + PlayerPrefs.GetInt("currentBalence");//change to coins pref
	}
}
