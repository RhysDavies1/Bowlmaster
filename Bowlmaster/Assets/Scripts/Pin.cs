﻿using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	public float standingThreshold = 5f;
	public float distToRaise = 40f;

	private Rigidbody rigidBody;

	void Start () {

		rigidBody = GetComponent<Rigidbody> ();

		IsStanding ();
	
	}

	public bool IsStanding(){

		Vector3 rotationInEuler = transform.rotation.eulerAngles;

		float tiltInX = Mathf.Abs(Mathf.DeltaAngle(rotationInEuler.x, 0));
		float tiltInZ = Mathf.Abs(Mathf.DeltaAngle(rotationInEuler.z, 0));

		if (tiltInX < standingThreshold && tiltInZ < standingThreshold) {

			return true;

		} else {

			return false;

		}

	}

	public void RaiseIfStanding(){
		
		if (IsStanding()){

			rigidBody.useGravity = false;
			transform.Translate (new Vector3 (0, distToRaise, 0), Space.World);

		}

	}

	public void Lower(){

		transform.Translate (new Vector3(0, -distToRaise, 0), Space.World);
		rigidBody.useGravity = true;

	}
}
