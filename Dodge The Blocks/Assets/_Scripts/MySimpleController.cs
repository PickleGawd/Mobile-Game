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

		if (grounded && Input.GetButtonDown(JumpAxis))
		{
			rb.velocity = new Vector2(rb.velocity.x, 10f);
			grounded = false;
		}
		if (Input.GetButtonDown(FireAxis))
		{
            Debug.Log("Fired Pressed");
            this.gameObject.GetComponent<PlayerScript>().Fire(Projectile, ProjectileVelocity);
		}
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
