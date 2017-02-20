using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoller2D : MonoBehaviour {

	public float speed = 10;
	Rigidbody rb;
	
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
		Debug.Log(Input.acceleration);
		rb.AddForce(Input.acceleration*speed,ForceMode.Acceleration);
		if(Input.touchCount==1) {
			rb.AddForce(Vector3.up, ForceMode.Impulse);
		}
	}
}
