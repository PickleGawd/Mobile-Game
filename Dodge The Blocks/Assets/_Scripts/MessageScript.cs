using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageScript : MonoBehaviour {

	public float showTime;

	// Use this for initialization
	void Start () {
		Color black = Color.black;
		GetComponent<Text>().color = black;
	}
	
	// Update is called once per frame
	void Update () {
		Color myColor = GetComponent<Text>().color;
		float ratio = Time.time / showTime;
		myColor.a = Mathf.Lerp(1, 0, ratio);
		GetComponent<Text>().color = myColor;
	}

}
