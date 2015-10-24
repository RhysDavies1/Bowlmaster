using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Rigidbody rigidBody;
	private AudioSource audioSource;

	public Vector3 launchVelocity;

	// Use this for initialization
	void Start () {

		rigidBody = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();

		Launch ();
	}

	public void Launch ()
	{
		rigidBody.velocity = launchVelocity;
		audioSource.Play ();
	}
}
