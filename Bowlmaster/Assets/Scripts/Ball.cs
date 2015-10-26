using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Rigidbody rigidBody;
	private AudioSource audioSource;

	public bool isInPlay = false;
	public Vector3 launchVelocity;

	// Use this for initialization
	void Start () {

		rigidBody = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();

		rigidBody.useGravity = false;
	}

	public void Launch (Vector3 velocity)
	{
		isInPlay = true;

		rigidBody.useGravity = true;
		rigidBody.velocity = velocity;

		audioSource.Play ();
	}
	
}
