using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour {

	private int currentBalance;

	private void Awake()
	{

	}

	
	// Update is called once per frame
	void Update () {
		currentBalance = PlayerPrefs.GetInt("currencyPref");

		gameObject.GetComponent<Text>().text = "Coins: " + currentBalance;
	}
}
