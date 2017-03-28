using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mole : MonoBehaviour {

	public int moleID;
	public enum MoleState {
		up = 0, 
		down = 1, 
		hit = 2
	}

	public MoleState moleState;
	private Animator anim;
	public WhackAMole moleManager;
	private float curTimer = 0;
	public float hitDur = 2;
	public float upDur = 3;
	public float downDur = 4;

	void Start() {
		anim = GetComponent<Animator>();
		moleState = (MoleState)Random.Range(0,2);
		// modify lengths over time
	}
	void Update () {
		if (curTimer<=0) {
			// move to next state
			if (moleState==MoleState.up) {
				moleState = MoleState.down;
				curTimer = downDur;
			} else if (moleState==MoleState.down) {
				moleState = MoleState.up;
				curTimer = upDur;
			} else if (moleState==MoleState.hit) {
				moleState = MoleState.down;
				curTimer = downDur;
			}
			anim.SetInteger("MoleState", (int)moleState);
		} else {
			curTimer-=Time.deltaTime;
		}
	}
	public void TappedOn() {
		Debug.Log(name+"Tapped on");
		if (moleState==MoleState.up) {
			moleState = MoleState.hit;
			curTimer = hitDur;
			anim.SetInteger("MoleState", (int)moleState);
			moleManager.MoleHit();
		} else if (moleState==MoleState.down) {
			// nothing, maybe mocking sfx
		} else if (moleState==MoleState.hit) {
			// nothing
		}
	}
}
