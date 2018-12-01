using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySimpleController : MonoBehaviour
{
	public string HorizontalAxis = "Horizontal";
	public string JumpAxis = "Jump";
	public string FireAxis = "Fire1";

	public GameObject Projectile;

	Rigidbody2D rb;

	public float velocity = 5f;
	public float ProjectileVelocity = 7f;

	//Power ups**
	public bool speedBoost = false;

	public int bulletsToFire = 3;

	[ReadOnly]
	public bool grounded;
	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		rb.velocity = new Vector2(Input.GetAxis("Horizontal") * velocity, rb.velocity.y);

		if (speedBoost)
		{
			Time.timeScale = 1.25f;
		}

		if (grounded && Input.GetButtonDown(JumpAxis))
		{
			rb.velocity = new Vector2(rb.velocity.x, 10f);
			grounded = false;
		}
		if (Input.GetButtonDown(FireAxis))
		{
            Debug.Log("Fired Pressed");
            Fire(Projectile, 20f, bulletsToFire);
		}
	}

	public void Fire(GameObject Projectile, float ProjectileVelocity = 7f, int bulletsToFire = 1)
	{
		for (int i = bulletsToFire; i > 0; i--)
		{
			GameObject obj = (GameObject)Instantiate(Projectile, transform.position + Vector3.right * 0.3f, Quaternion.identity);
			Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
			obj.GetComponent<Rigidbody2D>().velocity = new Vector2(ProjectileVelocity, 0f);

			Debug.Log("We fired!");

			StartCoroutine(Wait(0.01f));
		}

	}

	IEnumerator Wait(float time)
	{
		yield return new WaitForSeconds(time);
		Debug.Log("We Waited");
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		grounded = true;
	}
	void OnCollisionStay2D(Collision2D col)
	{
		grounded = true;
	}
	void OnCollisionExit2D(Collision2D col)
	{
		grounded = false;
	}
}
