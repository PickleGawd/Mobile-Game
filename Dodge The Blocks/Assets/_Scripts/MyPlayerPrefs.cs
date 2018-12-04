using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerPrefs : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		GameObject.DontDestroyOnLoad(gameObject);
		PlayerPrefs.SetInt("bullets", 1);
	}
}
