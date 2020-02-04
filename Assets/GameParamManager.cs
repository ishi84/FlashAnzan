using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParamManager : MonoBehaviour {

	static public GameParamManager instance;

	//桁数
	public static int digit;
	//表示個数
	public static int count;
	//表示終了までの時間
	public static float totalTime;

	//ランダム生成した数字を入れるリスト
	public static List<int> generatedNumberList;
	//数字の合計値
	public static int generatedNumberSum;
	//回答した数字
	public static int AnswerNum;

	void Awake() {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}
}