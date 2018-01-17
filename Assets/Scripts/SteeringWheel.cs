using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheel : MonoBehaviour {
	Camera camera;
	CarBehavior car;
	float initAngle;

	void Start () {
		camera = FindObjectOfType<Camera> ();
		car = FindObjectOfType<CarBehavior> ();
	}
	
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			initAngle = WheelAngle ();
		} else if (Input.GetMouseButton (0)) {
			float newAngle = WheelAngle ();
			float appliedRotation = Mathf.DeltaAngle (initAngle, newAngle);
			transform.Rotate(Vector3.forward, appliedRotation);
			car.transform.Rotate (Vector3.forward, appliedRotation / 4);

			initAngle = newAngle;
		}
	}

	private float WheelAngle()
	{
		Vector2 dir = transform.position - camera.ScreenToWorldPoint (Input.mousePosition);
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		return angle;
	}
}
