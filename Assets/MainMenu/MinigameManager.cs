using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour {

	public CanvasGroup endGameScreen;
	public CanvasGroup levelSelectScreen;
	public CanvasGroup mainScreen;
	public int curGameIndex {get; private set;}
	public int totalScore;

	void Start () {
		DontDestroyOnLoad(gameObject);
		ChangeScreen(mainScreen, true);
		ChangeScreen(levelSelectScreen, false);
		ChangeScreen(endGameScreen, false);
	}
	void Update() {

	}
	/// load the specified minigame scene and start playing
	public void StartMinigame(int index) {
		if (index < SceneManager.sceneCountInBuildSettings)
		{
			Debug.LogWarning("Not enough scenes in build settings!");
			return;
		}
		ChangeScreen(levelSelectScreen, false);
		curGameIndex = index;
		SceneManager.LoadScene(index);
	}
	/// Shows the end game screen and displays the final score to the user
	/// Allows the user to go back to the main menu
	public void FinishMinigame(int score=0) {
		ChangeScreen(endGameScreen, true);
		// do something with score
		
	}
	/// Return to the main menu
	/// Called by the end game screen
	public void ReturnToMenu() {
		ChangeScreen(endGameScreen, false);
		curGameIndex = 0;
		SceneManager.LoadScene(0);
		ChangeScreen(mainScreen, true);
	}
	/// Exits the application immediately
	public void ExitApp() {
		Application.Quit();
	}
	private void ChangeScreen(CanvasGroup cg, bool turnOn) {
		cg.alpha = turnOn ? 1 : 0;
		cg.interactable = turnOn;
		cg.blocksRaycasts = turnOn;
	}
	/// Called by the main menu screen's button to go to the level selection screen
	public void ShowLevelSelection() {
		ChangeScreen(mainScreen, false);
		ChangeScreen(levelSelectScreen, true);
	}
}
