using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RandomNumController : MonoBehaviour {

    //各数字の表示時間
    private float numDisplayTime;
    //暗転時間
    private float blackoutTime = 0.1f;
    //ランダム生成の最小、最大値
    private int numMin;
    private int numMax;
    //ランダム生成した数字のリスト
    private List<int> generatedNumberList;
    //生成した数字の合計値
    private int generatedNumberSum;

    void Start() {
        switch (GameParamManager.digit) {
            case 1:
                numMin = 1;
                numMax = 10;
                break;
            case 2:
                numMin = 10;
                numMax = 100;
                break;
            case 3:
                numMin = 100;
                numMax = 1000;
                break;
        }
        this.generatedNumberList = new List<int>();
        this.numDisplayTime = GameParamManager.totalTime / GameParamManager.count;
        StartCoroutine(RandomNumGenerate());
    }

    private IEnumerator RandomNumGenerate() {
        //count変数の数だけランダムな整数を生成
        for (int i = 0; i < GameParamManager.count; i++) {
            int num = Random.Range(this.numMin, this.numMax);
            //生成した数字を一定秒数表示
            GetComponent<Text>().text = num.ToString();
            yield return new WaitForSeconds(this.numDisplayTime - this.blackoutTime);
            //一瞬数字を消す
            GetComponent<Text>().text = "";
            yield return new WaitForSeconds(this.blackoutTime);
            //生成した数字をリストに追加
            this.generatedNumberList.Add(num);
        }
        //生成した数字の合計を計算
        foreach (int i in this.generatedNumberList) {
            this.generatedNumberSum += i;
        }
        //数字の保存関数呼び出し
        SaveGenerateNum();
        //回答入力用シーン呼び出し
        ChangeScene();
    }
    
    //生成した数字の保存用関数
    private void SaveGenerateNum() {
        GameParamManager.generatedNumberList = this.generatedNumberList;
        GameParamManager.generatedNumberSum = this.generatedNumberSum;
    }

    private void ChangeScene() {
        SceneManager.LoadScene("AnswerScene");
    }
}