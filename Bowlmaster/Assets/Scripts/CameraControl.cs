using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public Ball ball;
	private Vector3 offsetFromBall;

	void Start () {

		offsetFromBall = transform.position - ball.transform.position;
	
	}

	void Update () {

		if (ball.transform.position.z <= 1600){

			transform.position = ball.transform.position + offsetFromBall;

		}
	
	}

