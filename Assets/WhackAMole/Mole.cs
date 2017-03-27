using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour {

	public int moleID;
	public enum MoleState {
		up = 0, 
		down = 1, 
		hit = 2
	}

	public MoleState moleState;
	public Animator anim;
	public WhackAMole moleManager;
	private float curTimer = 0;
	public float hitLength = 2;
	public float upLength = 3;
	public float downLength = 4;

	void Start() {
		anim = GetComponent<Animator>();
	}
	void Update () {
		if (curTimer<=0) {
			// move to next state
			if (moleState==MoleState.up) {
				moleState = MoleState.down;
				curTimer = downLength;
			} else if (moleState==MoleState.down) {
				moleState = MoleState.up;
				curTimer = upLength;
			} else if (moleState==MoleState.hit) {
				moleState = MoleState.down;
				curTimer = downLength;
			}
			anim.SetInteger("MoleState", (int)moleState);
		} else {
			curTimer-=Time.deltaTime;
		}
	}
	// returns if the mole was up
	public bool TappedOn() {
		if (moleState==MoleState.up) {
			moleState = MoleState.hit;
			curTimer = hitLength;
			anim.SetInteger("MoleState", (int)moleState);
			return true;
		} else if (moleState==MoleState.down) {
			// nothing, maybe mocking sfx
		} else if (moleState==MoleState.hit) {
			// nothing
		}
		return false;
	}
}
