using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public Text standingDisplay;
	public int lastStandingCount = -1;

	private Ball ball;

	private bool ballEnteredBox = false;
	private float lastChangeTime;

	void Start (){

		ball = GameObject.FindObjectOfType<Ball>();
	
	}

	void Update () {

		standingDisplay.text = CountStanding ().ToString ();

		if (ballEnteredBox) {
		
			CheckStanding();

		}
	
	}

	public int CountStanding(){

		int standingPins = 0;

		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){

			if (pin.IsStanding()){

				standingPins ++;

			}

		}

		return standingPins;

	}

	void CheckStanding(){
	
		//Update the standing lastStandingCount
		//Call method PinsHaveSettled();

		int currentStanding = CountStanding ();

		if (currentStanding != lastStandingCount) {
		
			lastChangeTime = Time.time;

			lastStandingCount = currentStanding;

			return;
		
		}

		float settleTime = 3f;

		if ((Time.time - lastChangeTime) > settleTime) {
		
			PinsHaveSettled();
		
		}
	
	}

	void PinsHaveSettled(){

		ball.Reset ();
		
		lastStandingCount = -1;

		ballEnteredBox = false;

		standingDisplay.color = Color.green;

	}

	void OnTriggerEnter(Collider collider){

		GameObject obj = collider.gameObject;

		if (obj.GetComponent<Ball> ()) {
						
			ballEnteredBox = true;
		
			standingDisplay.color = Color.red;
		
		}

	}

	void OnTriggerExit(Collider collider){

		GameObject obj = collider.gameObject;

		if (obj.GetComponent<Pin> ()) {
		
			Destroy (obj);

		}

	}
}
