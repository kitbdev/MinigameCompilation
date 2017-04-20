using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class program : MonoBehaviour {

	private Rigidbody rb;
	public float speed;

	void Start() {
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate() {
		Vector3 movement = new Vector3 (Input.acceleration.x, 0.0f, Input.acceleration.y);
		rb.AddForce(movement * speed * Time.deltaTime);
	}
}
