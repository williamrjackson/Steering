using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehavior : MonoBehaviour {
	public float speed = 3;
	public Transform safeSpriteTransform;

	private bool isSafe = false;

	void Update () {
		if (!GameManager.instance.GetGameOver())
			transform.position += transform.up * speed * Time.deltaTime;
	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Wall") {
			if (isSafe) {
				SetSafe (false);
			} else {
				KillCar ();
			}
		}
	}

	public void SetSafe(bool safe)
	{
		safeSpriteTransform.gameObject.SetActive (safe);
		isSafe = safe;

	}

	private void KillCar()
	{
		transform.localScale = Vector3.one * .5f;
		GameManager.instance.SetGameOver();
	}
}
