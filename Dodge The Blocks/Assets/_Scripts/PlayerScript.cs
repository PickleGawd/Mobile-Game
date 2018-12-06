using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class PlayerScript : MonoBehaviour {

	public Text attempText;

	public int currentBalance;
	public int currencyInRun;
	public int lives;
	public int level;

	public float enemySpeed;

	public Vector2 startPos;

	public bool collectedCoin = false;

	

	public AudioClip hit;
	public AudioClip spawn;
	public AudioClip gameOverClip;

	AudioSource audioSource;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();

		currentBalance = PlayerPrefs.GetInt("currencyPref");
		lives = PlayerPrefs.GetInt("Lives");
	}

	// Use this for initialization
	void Start () {
		level = SceneManager.GetActiveScene().buildIndex;

		PlayerPrefs.SetInt("LevelPref", level);

		audioSource.clip = spawn;
		audioSource.Play();
	}
	
	// Update is called once per frame
    void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.tag == "Coin")
		{
			collectedCoin = true; //Touched Coin
			currentBalance++;
			SaveTotal();
			Destroy(other.gameObject);
			collectedCoin = false;
		}

		if (other.transform.tag == "Enemy")
		{
			audioSource.clip = hit;
			audioSource.Play();

			Debug.Log("Contact with Enemy");
			Death();
		}

		if (other.transform.tag == "1up")
		{
			lives++;
		}

		if (other.transform.tag == "DebugMode")
		{
			lives = 100;
			currentBalance = 10000000;
            PlayerPrefs.SetInt("bullets", 5);
			//gameObject.tag = "Enemy";
		}
	}


	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.transform.tag == "Obstacle")
		{
			audioSource.clip = hit;
			audioSource.Play();

			Debug.Log("Contact with Obstacle");
			Death();
		}
	}

	void SaveTotal()
	{
		PlayerPrefs.SetInt("currencyPref", currentBalance);
	}

	IEnumerator GameOver() //For attemps
	{
		audioSource.clip = gameOverClip;
		audioSource.Play();

		Debug.Log("Game Over");

		PlayerPrefs.SetInt("LevelPref", 1);
		PlayerPrefs.SetInt("Lives", 3);

		Time.timeScale = 0.1f;
		yield return new WaitForSeconds(gameOverClip.length / 10f);
		Time.timeScale = 1f;

		SceneManager.LoadScene(0);
	}

	

	void Death()
	{
		lives -= 1;
		PlayerPrefs.SetInt("Lives", lives);

		if (PlayerPrefs.GetInt("Lives") <= 0)
		{
			StartCoroutine(GameOver());
			
		} else
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

   
}
