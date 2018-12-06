using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyPlayerPrefs : MonoBehaviour {

	// Use this for initialization
	void Awake () {

		SetBool("firstTime", true);

		if (GetBool("firstTime"))
		{
			PlayerPrefs.SetInt("bullets", 1);
			PlayerPrefs.SetInt("Lives", 3);
			PlayerPrefs.SetInt("LevelPref", 1);
			SetBool("firstTime", false);
		}
	}

	//public void WritePref(string pref) {
	//	gameObject.GetComponent<Text>().text = pref + ": " + PlayerPrefs.GetInt(pref);
	//}

	public static void SetBool(string key, bool state)
	{
		PlayerPrefs.SetInt(key, state ? 1 : 0);
	}

	public static bool GetBool(string key)
	{
		int value = PlayerPrefs.GetInt(key);

		if (value == 1)
		{
			return true;
		}

		else
		{
			return false;
		}
	}
}
