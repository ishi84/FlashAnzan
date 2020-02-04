using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaitingSceneScript : MonoBehaviour {

	private Text text;
	private float second;


	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {
		second += Time.deltaTime;
		if (second >= 2) text.text = "START!!";
		if (second >= 4) SceneManager.LoadScene("GameScene");
	}
}
