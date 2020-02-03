using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class AnswerNumController : MonoBehaviour {

    //入力数字表示用オブジェクト
    private Text numDisplay;
    //入力した数字
    private string inputNum;
    private UnityEvent unityEvent;


    // Use this for initialization
    void Start() {
        inputNum = "";
        numDisplay = GameObject.Find("InputNumDisplay/Text").GetComponent<Text>();
        unityEvent = new UnityEvent ();
        unityEvent.AddListener (SaveAnswerNum);
    }

    // Update is called once per frame
    void Update() {
        if (this.numDisplay.text != this.inputNum) {
            this.numDisplay.text = this.inputNum;
        }
    }

    public void AddNumber(string buttonText) {
        if (buttonText != "0" || this.inputNum.Length > 0) {
            if (this.inputNum.Length < 8) {
                this.inputNum += buttonText;
            }
        }
    }
    public void RemoveNumber() {
        if (this.inputNum.Length > 0)
            this.inputNum = this.inputNum.Remove(this.inputNum.Length - 1, 1);
    }

    public void LoadResultScene() {
        unityEvent.Invoke();
        SceneManager.LoadScene("ResultScene");
    }

    public void SaveAnswerNum() {
        GameParamManager.AnswerNum = int.Parse(this.inputNum);
    }
}