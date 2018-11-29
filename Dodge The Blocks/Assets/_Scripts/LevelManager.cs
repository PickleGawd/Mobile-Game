using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	private int level;

	// Use this for initialization
	void Start () {
		level = PlayerPrefs.GetInt("LevelPref");
		if (level == 0)
		{
			level = SceneManager.GetActiveScene().buildIndex + 1;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

   public void LoadLevel(string name)
	{
		Debug.Log("New Level Load " + name);
		SceneManager.LoadScene(name);
	}

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

	public void StartGame()
	{
		SceneManager.LoadScene(level);
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.transform.tag == "Player")
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

		}
	}

}
