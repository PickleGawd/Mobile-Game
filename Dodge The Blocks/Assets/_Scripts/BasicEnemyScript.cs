using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyScript : MonoBehaviour {

	private Vector3 target;
	public float enemySpeed = 4.5f;

	// Use this for initialization
	void Start()
	{
		target = new Vector3(-5, transform.position.y);
	}

	// Update is called once per frame
	void Update()
	{
		float step = enemySpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target, step);
	}
}
