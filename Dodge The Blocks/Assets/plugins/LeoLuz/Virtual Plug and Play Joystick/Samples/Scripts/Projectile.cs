﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.transform.tag != "Coin" && other.transform.name != "RightWall") {
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
		destroyIn(1f);
		
    }

	IEnumerator destroyIn(float time) {
		yield return new WaitForSeconds(time);
		Destroy(gameObject);
	}
}
