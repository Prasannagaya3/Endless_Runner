﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeRotation : MonoBehaviour
{

	public float turnSpeed;
	private Vector2 startPos;

	void OnMouseDrag ()
	{
		float rotationX = Input.GetAxis ("Mouse X");
		float rotationY = Input.GetAxis ("Mouse Y");

		//left and right
		if (Mathf.Abs (rotationX) > Mathf.Abs (rotationY)) {
			if (rotationX > 0)
				transform.Rotate (Vector3.up, turnSpeed * Time.deltaTime);
			else
				transform.Rotate (Vector3.up, -turnSpeed * Time.deltaTime);
		}

		//up and down
		if (Mathf.Abs (rotationX) < Mathf.Abs (rotationY)) {
			if (rotationY < 0) {
				transform.Rotate (Vector3.right, turnSpeed * Time.deltaTime);
			} else {
				transform.Rotate (Vector3.right, -turnSpeed * Time.deltaTime);
			}
		}
		float minRotation = -45;
		float maxRotation = 45;
		Vector3 currentRotation = transform.localRotation.eulerAngles;
		currentRotation.x = Mathf.Clamp (currentRotation.x, minRotation, maxRotation);
		transform.localRotation = Quaternion.Euler (currentRotation);
	}

	void Update ()
	{
		OnMouseDrag ();
	}
}
