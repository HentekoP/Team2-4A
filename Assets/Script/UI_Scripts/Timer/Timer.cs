//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;

//public class Timer : MonoBehaviour
//{
//	//　タイマーを表示するテキスト
//	private TextMeshProUGUI timerText;
//	//　経過秒数
//	private float seconds;
//	//　ストップウォッチ用フィールド
//	private Stopwatch stopWatch;

//	// Start is called before the first frame update
//	void Start()
//	{
//		//　コンポーネントの取得
//		timerText = GetComponent<TextMeshProUGUI>();
//		//　ストップウォッチクラスを使う場合
//		stopWatch = new Stopwatch();
//	}

//	void Update()
//	{
//		//　ゲームオーバー時は以降何もしない
//		if (gameManager.GameOver)
//		{
//			return;
//		}
//		//　時間を計測する
//		TakeTime();

//		////　ストップウォッチクラスを使う場合
//		//stopWatch.Stop();
//		//var timeSpan = stopWatch.Elapsed;
//		//timerText.SetText("{0:00}:{1:00}:{2:00}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
//		//stopWatch.Start();
//	}
//	//　時間計測メソッド
//	void TakeTime()
//	{
//		//　1秒増やす
//		seconds += Time.deltaTime;
//		//　TimeSpanクラスを使って時間秒を取得する為の準備
//		var timeSpan = new TimeSpan(0, 0, (int)seconds);
//		//　数値を更新
//		timerText.SetText("{0:00}:{1:00}:{2:00}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
//		//　あまりに時間がかかったらゲームオーバー
//		if (seconds >= 60 * 60 * 60)
//		{
//			gameManager.EndGame();
//		}
//	}
//	//　経過時間を返す
//	public int GetSeconds()
//	{
//		return (int)seconds;
//	}
//}
