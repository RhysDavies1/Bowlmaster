using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Rigidbody rigidBody;
	private AudioSource audioSource;
	private Vector3 ballStartPos;

	public bool isInPlay = false;
	public Vector3 launchVelocity;

	// Use this for initialization
	void Start () {

		rigidBody = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();

		ballStartPos = transform.position;

		rigidBody.useGravity = false;
	}

	public void Launch (Vector3 velocity)
	{
		isInPlay = true;

		rigidBody.useGravity = true;
		rigidBody.velocity = velocity;

		audioSource.Play ();
	}

	public void Reset(){

		isInPlay = false;
		transform.position = ballStartPos;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
		rigidBody.useGravity = false;

	}
	
}
