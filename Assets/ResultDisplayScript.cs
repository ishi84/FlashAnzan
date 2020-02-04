using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultDisplayScript : MonoBehaviour {

	[SerializeField] private Text resultText;
	[SerializeField] private Text correctAnswerText;
	[SerializeField] private Text inputAnswerText;

	// Use this for initialization
	void Start () {
		if(GameParamManager.generatedNumberSum == GameParamManager.AnswerNum) {
			this.resultText.text = "〇正解";
		} else {
			this.resultText.text = "×不正解";
		}
		
		this.correctAnswerText.text = "解答：" + GameParamManager.generatedNumberSum.ToString();
		this.inputAnswerText.text = "あなたの答え：" + GameParamManager.AnswerNum.ToString();
	}
}
