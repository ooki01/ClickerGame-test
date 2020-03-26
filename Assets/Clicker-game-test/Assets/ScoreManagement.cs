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
    //購入後の値
    private int AfterPurchaseScore;
    //モーダルダイアログ
    [SerializeField]
    private GameObject YesNoPrefab;
    //　データベース
    [SerializeField]
    private ShopDataBase shopDataBase;
    //モーダルダイアログに表示する画像
    public Image AnimalImage;

    // Start is called before the first frame update
    void Start()
    {

        //保存したscoreの値を復元
        int score = PlayerPrefs.GetInt("score");

        //CoinTextを取得
        this.CoinText = GameObject.Find("CoinText");

        //CoinTextに表示
        CoinText.GetComponent<Text>().text = score.ToString() + "G";

        //scoreを保存
        PlayerPrefs.SetInt("score", score);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Purchase(PurchasingInformation PurchaseProcessing)//PurchasingInformation型のPurchaseProcessingという引数(クラス名は型名となる)
    {
        //YesNoPrefabオブジェクトを生成して、GameObject型のconfirmに代入
        GameObject confirm = Instantiate(YesNoPrefab, transform.GetComponentInParent<Canvas>().transform);

        //Dialogcontrollerを取得
        Dialogcontroller dc = confirm.GetComponent<Dialogcontroller>();

        //アイテムイメージをAnimalImageに代入
        AnimalImage = dc.itemImage;

        //スプライト化したAnimalImageをonclick()に設定したファイルの画像を代入
        AnimalImage.sprite = PurchaseProcessing.GetIcon();
        Debug.Log(AnimalImage.sprite);
        Debug.Log(PurchaseProcessing.GetIcon());

        //ダイアログテキストを表示
        dc.ShowDialog(PurchaseProcessing.GetAnimalPrice() + "G" + "で購入しますか？");

        //PurchaseScore変数に、onclick()に設定したファイルの価格を代入
        PurchaseScore = PurchaseProcessing.GetAnimalPrice();//引数名.関数名

        Debug.Log("AnimalPrice" + PurchaseProcessing.GetAnimalPrice());

        //はいボタンが押されたときの動作   //ラムダ式を使うことで、関数内で関数を定義できる
        dc.YesButton.onClick.AddListener(() =>
        {
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

            Debug.Log(PurchaseProcessing.GetAnimalPrice() + "で購入しました");



            //YesNoPrefabを破壊
            Destroy(confirm);
        });
    }
}