using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MyPlayerPrefs : MonoBehaviour {

    GameObject[] Prefs;

    public bool oneTime = true;

	// Use this for initialization
	void Awake () {
        SetPrefs();//Make reset button to call this
	}

	//public void WritePref(string pref) {
	//	gameObject.GetComponent<Text>().text = pref + ": " + PlayerPrefs.GetInt(pref);
	//}

    public void SetPrefs() 
    {
        PlayerPrefs.SetInt("bullets", 1);
        PlayerPrefs.SetInt("Lives", 3);
        PlayerPrefs.SetInt("LevelPref", 1);
        PlayerPrefs.SetInt("coins", 0);

        Debug.Log("PlayerPrefs Set");
        //Debug.Log(oneTime);
    }

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
