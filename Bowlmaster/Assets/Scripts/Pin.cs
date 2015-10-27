using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	public float standingThreshold = 5f;

	void Start () {

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
}
