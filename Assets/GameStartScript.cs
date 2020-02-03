using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStartScript : MonoBehaviour {

	//各ドロップダウンの値を格納
	[SerializeField] private Dropdown digitSet;
	[SerializeField] private Dropdown numCountSet;
	[SerializeField] private Dropdown totalTimeSet;

	// Use this for initialization
	void Start() {
		digitSet.value = 0;
		numCountSet.value = 1;
		totalTimeSet.value = 6;
	}

	public void SaveGameParam() {
		GameParamManager.digit = int.Parse(digitSet.options[digitSet.value].text);
		GameParamManager.count = int.Parse(numCountSet.options[numCountSet.value].text);
		GameParamManager.totalTime = int.Parse(totalTimeSet.options[totalTimeSet.value].text);
		StartGame();
	}
	private void StartGame() {
		SceneManager.LoadScene("GameScene");
	}
}