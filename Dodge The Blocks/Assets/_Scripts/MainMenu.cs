﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject levelButtonPrefab;
	public GameObject LevelButtonContainer;

	private void Start()
	{
		Sprite[] thumbnails = Resources.LoadAll<Sprite>("Levels");
		foreach(Sprite thumbnail in thumbnails)
		{
			GameObject container = Instantiate(levelButtonPrefab) as GameObject;
			container.GetComponent<Image>().sprite = thumbnail;
			container.transform.SetParent(LevelButtonContainer.transform, false);

			string sceneName = thumbnail.name;
			container.GetComponent<Button>().onClick.AddListener(() => LoadLevel(sceneName));

		}
	}

	private void LoadLevel(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
}