using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreManagement : MonoBehaviour
{

    //CoinTextを入れておくための変数
    private GameObject CoinText;
    //購入時の値
    private int PurchaseScore;
    //はいボタン
    private GameObject YesButton;
    //いいえボタン
    private GameObject NoButton;
    //購入後の値
    private int AfterPurchaseScore;
    //確認画面
    private GameObject YesNoCanvas;
    //　データベース
    [SerializeField]
    private ShopDataBase shopDataBase;
    //yes
    public bool yes = false;

    // Start is called before the first frame update
    void Start()
    {
        //確認画面
        YesNoCanvas = GameObject.Find("YesNoCanvas");
        //確認画面を非表示
        YesNoCanvas.SetActive(false);

        //YesButtonを取得
        YesButton = GameObject.Find("YesButton");
        //NoButtonを取得
        NoButton = GameObject.Find("NoButton");

        //保存したscoreの値を復元
        int score = PlayerPrefs.GetInt("score");
        Debug.Log("score" + score);

        //CoinTextを取得
        this.CoinText = GameObject.Find("CoinText");

        //CoinTextに表示
        CoinText.GetComponent<Text>().text = score.ToString() + "G";
        Debug.Log("score" + score);

        //scoreを保存
        PlayerPrefs.SetInt("score", score);

        PurchaseScore = shopDataBase.GetProductLists()[0].GetAnimalPrice();
        Debug.Log("PurchaseScore" + PurchaseScore);
}

    // Update is called once per frame
    void Update()
    {

    }

    public void Purchase(PurchasingInformation PurchaseProcessing)//PurchasingInformation型のPurchaseProcessingという引数(クラス名は型名となる)
    {
        //確認画面を表示
        YesNoCanvas.SetActive(true);

        //PurchaseScore変数に、onclick()に設定したファイルの価格を代入
        PurchaseScore = PurchaseProcessing.GetAnimalPrice();//引数名.関数名
        Debug.Log("AnimalPrice" + PurchaseProcessing.GetAnimalPrice());

        //score(値)の復元
        int score = PlayerPrefs.GetInt("score");

        //どうぶつを購入
        AfterPurchaseScore = score - PurchaseScore;

        //CoinTextに表示
        CoinText.GetComponent<Text>().text = AfterPurchaseScore.ToString() + "G";

        //scoreを更新
        score = AfterPurchaseScore;

        //scoreを保存
        PlayerPrefs.SetInt("score", score);

    }
}
