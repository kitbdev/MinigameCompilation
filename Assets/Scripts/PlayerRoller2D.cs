using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoller2D : MonoBehaviour {



	Rigidbody rb;
	
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
		rb.AddForce(Input.gyro.gravity, ForceMode.Acceleration);
		if(Input.touchCount==1) {
			Instantiate(gameObject, Camera.main.ScreenToWorldPoint(Input.touches[0].position), Quaternion.identity);
		}
	}
}
