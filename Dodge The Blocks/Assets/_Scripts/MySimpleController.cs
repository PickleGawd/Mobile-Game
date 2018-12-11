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
	public bool speedBoost = true;

	private int bullets;

	public bool hasFired = false;

	[ReadOnly]
	public bool grounded;
	// Use this for initialization
	void Start()
	{
		bullets = PlayerPrefs.GetInt("bullets");
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
		if (Input.GetButtonDown(FireAxis) && !hasFired)
		{
            Debug.Log("Fired Pressed");
			
			Fire(Projectile, 20f);
			//StartCoroutine(Wait(1f, hasFired));
			
			
		}
	}

	public void Fire(GameObject Projectile, float ProjectileVelocity = 7f)
	{
		GameObject obj = (GameObject)Instantiate(Projectile, transform.position + Vector3.right * 0.3f, Quaternion.identity);
		Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		obj.GetComponent<Rigidbody2D>().velocity = new Vector2(ProjectileVelocity, 0f);

		if (bullets > 1) {
			Vector3 myPos = new Vector3();
			

			for (int i = bullets - 1; i > 0;  i--) {
				myPos = new Vector3(Random.Range(transform.position.x + 1f, transform.position.x + 5), Random.Range(transform.position.y + 3f, transform.position.y - 3), 0);

				GameObject projectile = (GameObject)Instantiate(Projectile, myPos, Quaternion.identity);
				Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());
				projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(ProjectileVelocity, 0f);
			}
		}
		Debug.Log("We fired " + bullets);
	}

	IEnumerator Wait(float time, bool? waited = null)
	{
		waited = false;
		yield return new WaitForSeconds(time);
		waited = true;
		Debug.Log("We Waited " + time + " seconds");
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
