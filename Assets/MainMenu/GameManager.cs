using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public CanvasGroup endGameScreen;
	public int curGameIndex {get; private set;}

	void Start () {
		DontDestroyOnLoad(gameObject);
		ToggleEndGameScreen(false);
	}
	
	public void StartGame(int index) {
		if (index < SceneManager.sceneCountInBuildSettings)
		{
			Debug.LogWarning("Not enough scenes in build settings!");
			return;
		}
		curGameIndex = index;
		SceneManager.LoadScene(index);
	}
	public void FinishGame(int score=0) {
		ToggleEndGameScreen(true);
		// do something with score
		
	}
	public void ReturnToMenu() {
		ToggleEndGameScreen(false);
		curGameIndex = 0;
		SceneManager.LoadScene(0);
	}
	private void ToggleEndGameScreen(bool turnOn) {
		endGameScreen.alpha = turnOn ? 1 : 0;
		endGameScreen.interactable = turnOn;
		endGameScreen.blocksRaycasts = turnOn;
	}
}
