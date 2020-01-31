using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomNumController : MonoBehaviour {

    //表示終了までの時間
    private float totalTime = 3f;
    //各数字の表示時間
    private float numDisplayTime;
    //
    private float interval;
    //桁数
    private int digit = 3;
    //表示個数
    private int count = 5;
    //暗転時間
    private float blackoutTime = 0.2f;
    //ランダム生成の最小、最大値
    private int numMin;
    private int numMax;

    //ランダム生成した数字を入れるリスト
    List<int> generatedNumberList;
    //数字の合計値
    private int correctAnswer;

    void Start() {
        switch (digit) {
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
        generatedNumberList = new List<int>();
        numDisplayTime = totalTime / count;
        StartCoroutine("RandomNumGenerate");
    }

    void Update() {
        // interval += Time.deltaTime;
        // if (interval >= 2) {
        //     int x = Random.Range(10, 100);
        //     GetComponent<Text>().text = x.ToString();
        //     interval = 0;
        // }
    }

    IEnumerator RandomNumGenerate() {
        //count変数の数だけランダムな整数を生成
        for (int i = 0; i < this.count; i++) {
            int num = Random.Range(numMin, numMax);
            Debug.Log(num);
            //生成した数字を一定秒数表示
            GetComponent<Text>().text = num.ToString();
            yield return new WaitForSeconds(numDisplayTime - blackoutTime);
            //一瞬数字を消す
            GetComponent<Text>().text = "";
            yield return new WaitForSeconds(blackoutTime);
            //数字をリストに追加
            generatedNumberList.Add(num);
        }
        Debug.Log("経過時間" + Time.time);
        
        //生成した数字の合計を計算
        foreach (int i in generatedNumberList)
        {
            correctAnswer += i;
        }
        Debug.Log(correctAnswer);
    }
}

// １０級～７級 1桁 口数は級が上がるごとに4・6・8・10口  秒は級の口数と同様
// ６級～２級   ２桁    口数は級が上がるごとに3・4・5・7・10    秒は級の口数と同様
// １級～２段   ３桁    口数は級が上がるごとに5・7・10口    秒は級の口数と同様
// ３段～8段    ３桁    口数１０口  秒は段が上がるごとに7・5・4.5・4・3.5・3秒
// 9～10段  ３桁    口数15口    秒は段が上がるごとに4・3秒