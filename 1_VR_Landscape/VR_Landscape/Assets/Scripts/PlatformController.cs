using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

	// movement target
	public Transform target;

	// destinations / targets
	public Transform[] targets;

	// speed
	public float speed = 1;

	// flag that sets whether we are moving or not
	bool isMoving = false;

	// next destination index
	int nextIndex; 

	// Use this for initialization
	void Start () {
		transform.position = targets [0].position;

		nextIndex = 1;

	}
	
	// Update is called once per frame
	void Update () {
		//check for input
		HandleInput();

		// move our platform
		HandleMovement ();

	}

	void HandleMovement(){

		if (!isMoving)
			return;

		// calculate the distance from target
		float distance = Vector3.Distance (transform.position, targets[nextIndex].position);

		// have we arrived?
		if (distance > 0) {

			// calculate how much we need to move(step) d = v*t
			float step = speed * Time.deltaTime;

			// move by the step
			transform.position = Vector3.MoveTowards (transform.position, targets[nextIndex].position, step);
		} 
		// if we have arrived we should update nextIndex
		else {
			
			nextIndex++;
			if (nextIndex >= targets.Length)
				nextIndex = 0;
			isMoving = false;
		}


	}

	void HandleInput(){
		// Check for Fire1 axis
		if (Input.GetButtonDown("Fire1")) {
			isMoving = !isMoving;
		}
	}
}
