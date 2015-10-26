using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Ball))]

public class DragLaunch : MonoBehaviour {

	private Ball ball;
	private Vector3 dragStart, dragEnd;
	private float startTime, endTime;
	private float minX = -40f;
	private float maxX = 40f;

	void Start () {

		ball = GetComponent<Ball> ();
	
	}

	public void MoveStart(float xNudge){

		if (! ball.isInPlay) {
		
			ball.transform.Translate (new Vector3 (xNudge, 0, 0));
			ball.transform.position = new Vector3 (Mathf.Clamp (ball.transform.position.x, minX, maxX), ball.transform.position.y, ball.transform.position.z);

		}

	}

	public void DragStart (){

		//Capture time and position of drag start (mouse click)
		if (! ball.isInPlay) {

			dragStart = Input.mousePosition;
			startTime = Time.time;

		}

	}

	public void DragEnd () {

		//Launch the ball
		//Speed is distance over time

		if (! ball.isInPlay) {

			dragEnd = Input.mousePosition;
			endTime = Time.time;

			float dragDuration = endTime - startTime;

			float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
			float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

			Vector3 launchVelocity = new Vector3 (launchSpeedX, 0, launchSpeedZ);

			ball.Launch (launchVelocity);

		}

	}

}
