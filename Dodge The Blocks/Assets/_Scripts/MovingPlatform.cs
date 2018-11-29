using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public Vector3 target;
	public float speed;

	private bool colliding;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		Debug.Log(colliding);
		if (colliding)
		{
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target, step);
		}
		
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		colliding = true;
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		colliding = false;
	}
}
