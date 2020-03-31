using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class SliderController : MonoBehaviour
{

	//シーン変更時にも使用するため、staticな変数で宣言
	[Range(0, 9999)] public static int score = 1000;

	//タイマーが開始した時刻から経過した時間を示す変数
	private float elapsedtime;

	//現在のスライダーの値(分)を入れておくための変数
	private float NowValue;

	//カウントを開始したスライダーの値(分)を入れておくための変数
	private float CountValue;

	//スライダーの秒数を示す変数
	private float SliderSeconds;

	//Timerの状態を確認するフラグ
	private bool iscount = false;

	//経過時間(分)を取得するための変数
	private float save;

	//経過時間を計算するための変数
	private int Scoreoffline;

	Slider TimeSlider;
	private GameObject StopButton;
	private GameObject StartButton;
	private GameObject ResetButton;
	private GameObject RestartButton;
	private GameObject ShopButton;
	private GameObject GaugeText;
	private GameObject CoinText;


	//タイマーがスタートした時刻
	System.DateTime StartTime = System.DateTime.MinValue;

	// Use this for initialization
	void Start()
	{
		//GaugeTextを取得
		this.GaugeText = GameObject.Find("GaugeText");
		//CoinTextを取得
		this.CoinText = GameObject.Find("CoinText");

		StartButton = GameObject.Find("StartButton");
		StopButton = GameObject.Find("StopButton");
		ResetButton = GameObject.Find("ResetButton");
		RestartButton = GameObject.Find("RestartButton");
		ShopButton = GameObject.Find("ShopButton");

		//ショップボタンの表示
		ShopButton.gameObject.GetComponent<CanvasGroup>().alpha = 1;
		ShopButton.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;

		//SliderからTImeSliderを取得
		TimeSlider = GetComponent<Slider>();

		//保存したscoreの値を復元
		score = PlayerPrefs.GetInt("score");

		//CoinTextに、保存したscoreを表示
		CoinText.GetComponent<Text>().text = score + "G";

		if (PlayerPrefs.HasKey("SliderSeconds"))
		{
			Debug.Log("スライダーのびょうすうあるよ");
			//カウントを開始
			iscount = true;

			//保存したスライダーの値(秒)を復元
			SliderSeconds = PlayerPrefs.GetFloat("SliderSeconds");

			//保存したスライダーの値(秒)を復元
			CountValue = PlayerPrefs.GetFloat("CountValue");

			Debug.Log("StartCountValue" + CountValue);

			// 保存した文字列をDateTime 型として復元。
			System.DateTime savetime = System.DateTime.Parse(PlayerPrefs.GetString("DateTime.Now"));

			// 現在時刻と保存時刻を比較して、TimeSpan 型として取得。
			System.TimeSpan spantime = System.DateTime.Now - savetime;

			//経過時刻(秒)を取得
			double totalTime = spantime.TotalSeconds;

			//float型に変換
			float save = (float)totalTime;

			Debug.Log("SliderSeconds" + SliderSeconds);


			//スライダーの値(秒数)から、経過時間を引く
			SliderSeconds -= save;

			//分を計算
			float minutes = SliderSeconds / 60;
			// あまりの秒を計算
			float seconds = SliderSeconds % 60;
			Debug.Log("SliderSeconds" + SliderSeconds);

			//オフライン時のscoreの値を計算
			Scoreoffline = (int)save / 3 * 100;
			Debug.Log("Scoreoffline" + Scoreoffline);
			Debug.Log("save" + save);
			Debug.Log("StartScore" + score);

			//復元後のスライダーの秒数を代入
			NowValue = SliderSeconds;

			//オフラインで経過した時間を含めたscoreを計算
			score = score + Scoreoffline;
			Debug.Log("TotalScore" + score);


			//スライダーの値にminutesを代入
			TimeSlider.value = minutes;

			//分と秒を表示
			this.GaugeText.GetComponent<Text>().text = minutes.ToString() + (":") + seconds.ToString("00");

			CoinText.GetComponent<Text>().text = score + "G";


			//とめるボタンと中断するボタンの表示
			StopButton.gameObject.GetComponent<CanvasGroup>().alpha = 1;
			StopButton.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
			ResetButton.gameObject.GetComponent<CanvasGroup>().alpha = 1;
			ResetButton.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
			//はじめるボタンの非表示
			StartButton.gameObject.GetComponent<CanvasGroup>().alpha = 0;
			StartButton.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
			//ショップボタンの非表示
			ShopButton.gameObject.GetComponent<CanvasGroup>().alpha = 0;
			ShopButton.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;

			Debug.Log("復元後CountValue" + CountValue);
			Debug.Log("復元後score" + score);
		}

		TimeSlider = GetComponent<Slider>();

		float maxTime = 120f;

		TimeSlider.maxValue = maxTime;

		Debug.Log("Start" + score);
		//scoreの値を保存
		PlayerPrefs.SetInt("score", score);

	}

	// Update is called once per frame
	void Update()
	{
		//現在のスライダーの値(秒)
		NowValue = SliderSeconds;

		//カウントを開始したスライダー値から現在のスライダーの値(分)を引いた差分
		this.elapsedtime = CountValue - NowValue;
		if (iscount == true && TimeSlider.value > 0)
		{
			//スライダーの値(秒)を減らしていく
			SliderSeconds -= Time.deltaTime;

			// 切り上げをする
			int tSeconds = (int)Math.Ceiling(SliderSeconds);

			// 60で割った値が分
			int minutes = tSeconds / 60;

			// 60で割ったあまりが秒
			int seconds = tSeconds % 60;

			//スライダーの値に分を代入
			TimeSlider.value = minutes;

			//分と秒を表示
			this.GaugeText.GetComponent<Text>().text = minutes.ToString() + (":") + seconds.ToString("00");

			//とめるボタンと中断するボタンの表示
			StopButton.gameObject.GetComponent<CanvasGroup>().alpha = 1;
			StopButton.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
			ResetButton.gameObject.GetComponent<CanvasGroup>().alpha = 1;
			ResetButton.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
			//はじめるボタンの非表示
			StartButton.gameObject.GetComponent<CanvasGroup>().alpha = 0;
			StartButton.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
		//カウントが0になった場合、スライダーの値をゼロにする
		else if (iscount == true && TimeSlider.value <= 0)
		{
			SliderSeconds = 0f;
		}

		//差分が3秒を超えるたびに、Scoreの値に100ずつ加えて、CoinTextに表示
		if (this.elapsedtime >= 3)
		{
			Debug.Log("5CountValue " + CountValue);
			//CountValueの値(秒)を更新
			CountValue = SliderSeconds;

			//scoreを100ずつ追加
			score += 100;
			//CoinTextを表示
			CoinText.GetComponent<Text>().text = score + "G";
		}

	}
	public void CountStart()
	{
		//カウントを開始
		iscount = true;

		Debug.Log("CountStart" + SliderSeconds);
		//TimeSlider.value(分)の秒数を、RemaingTimeに代入
		SliderSeconds = TimeSlider.value * 60;

		//カウントを開始したときのスライダーの値(秒)
		CountValue = SliderSeconds;
		Debug.Log(SliderSeconds);

		//開始の時刻
		StartTime = System.DateTime.Now;

		//ショップボタンの非表示
		ShopButton.gameObject.GetComponent<CanvasGroup>().alpha = 0;
		ShopButton.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
		//スタートボタンを非表示にする
		StartButton.gameObject.GetComponent<CanvasGroup>().alpha = 0;
		StartButton.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
		//とめるボタンと中断するボタンの表示
		StopButton.gameObject.GetComponent<CanvasGroup>().alpha = 1;
		StopButton.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
		ResetButton.gameObject.GetComponent<CanvasGroup>().alpha = 1;
		ResetButton.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;

		Debug.Log("Start Timer at " + StartTime.ToString());
		Debug.Log("SliderSeconds" + SliderSeconds);
		Debug.Log("CountValue" + CountValue);
	}

	public void Stop()
	{
		if (iscount == true)
		{
			iscount = false;
			PlayerPrefs.SetFloat("m_SliderSeconds", SliderSeconds);
			PlayerPrefs.SetFloat("m_CountValue", CountValue);
			PlayerPrefs.Save();
			Debug.Log("とまったよ");
			//やめるボタンの非表示
			ResetButton.gameObject.GetComponent<CanvasGroup>().alpha = 0;
			ResetButton.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
			//中断ボタンの非表示
			StopButton.gameObject.GetComponent<CanvasGroup>().alpha = 0;
			StopButton.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
			//再開ボタンの表示
			RestartButton.gameObject.GetComponent<CanvasGroup>().alpha = 1;
			RestartButton.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
		}
		else
		{
			iscount = true;
			//とめるボタンと中断するボタンの表示
			StopButton.gameObject.GetComponent<CanvasGroup>().alpha = 1;
			StopButton.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
			ResetButton.gameObject.GetComponent<CanvasGroup>().alpha = 1;
			ResetButton.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
			//再開ボタンの非表示
			RestartButton.gameObject.GetComponent<CanvasGroup>().alpha = 0;
			RestartButton.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
		}

	}


	public void Reset()
	{
		//カウントをとめる
		iscount = false;

		//スライダーの秒数を削除
		PlayerPrefs.DeleteKey("SliderSeconds");

		//scoreの値を保存
		PlayerPrefs.SetInt("score", score);

		//スライダーの値を0にする
		TimeSlider.value = 0f;

		//0:00の表記をテキストに表示させる
		this.GaugeText.GetComponent<Text>().text = TimeSlider.value.ToString() + (":") + ("00");

		//スタートボタンの表示
		StartButton.gameObject.GetComponent<CanvasGroup>().alpha = 1;
		StartButton.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
		//中断するボタンの非表示
		ResetButton.gameObject.GetComponent<CanvasGroup>().alpha = 0;
		ResetButton.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
		//とめるボタンの非表示
		StopButton.gameObject.GetComponent<CanvasGroup>().alpha = 0;
		StopButton.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
		//ショップボタンの表示
		ShopButton.gameObject.GetComponent<CanvasGroup>().alpha = 1;
		ShopButton.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	private void OnApplicationQuit()
	{
		if (iscount == true && TimeSlider.value > 0)
		{
			PlayerPrefs.SetFloat("SliderSeconds", SliderSeconds);
			PlayerPrefs.SetString("DateTime.Now", System.DateTime.Now.ToString());
			PlayerPrefs.Save();
		}
		PlayerPrefs.SetFloat("CountValue", CountValue);
		PlayerPrefs.SetInt("score", score);
		PlayerPrefs.Save();
		Debug.Log("保存後CountValue"+ CountValue);
		Debug.Log("保存後score" + score);

	}

	public void OnValuechanged()
	{
		float sliderValue = TimeSlider.value;

		// 5で割って整数に丸めて5倍、5分ごとの値とする
		sliderValue = Mathf.Round(sliderValue / 5) * 5;

		//GaugeTextに表示
		this.GaugeText.GetComponent<Text>().text = sliderValue.ToString("f2").Replace(".", ":");
	}


}