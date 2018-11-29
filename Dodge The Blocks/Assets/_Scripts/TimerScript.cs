using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

	public GameObject timer;

	private bool startTimer = true;

	private int countDown = 10;
	
	// Update is called once per frame
	void Update () {

		gameObject.GetComponent<Text>().text = "Time Remaining: " + countDown;

		if (startTimer)
		{
			StartCoroutine(StartTime());
			startTimer = false;
		}

		if (countDown <= 0)
		{
			//PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") - 1);
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	IEnumerator StartTime()
	{
		yield return new WaitForSeconds(1f);

		startTimer = true;
		countDown--;
	}
}
