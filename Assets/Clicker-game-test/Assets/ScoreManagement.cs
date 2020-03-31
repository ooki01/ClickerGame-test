using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// このスクリプトは何故か ShopScene の中の「２つ」のオブジェクトにアタッチされている。片方は間違えてアタッチされているんじゃないかと推測している。
/// </summary>
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

    public GameObject animal;
    Dictionary<int, int> m_stock;

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

        // 在庫を読み込む
        string json = PlayerPrefs.GetString("StockData");
        Debug.LogFormat("json: {0}", json);
        if (json.Length < 3)
        {
            // 初期データを作る（100個ずつ）
            m_stock = new Dictionary<int, int>()
            {
                { 1, 100 },
                { 2, 100 },
            };
        }
        else
        {
            m_stock = JsonUtility.FromJson<Serialization<int, int>>(json).ToDictionary();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Purchase(ShopItemController item)
    {
        //YesNoPrefabオブジェクトを生成して、GameObject型のconfirmに代入
        GameObject confirm = Instantiate(YesNoPrefab, transform.GetComponentInParent<Canvas>().transform);

        //Dialogcontrollerを取得
        Dialogcontroller dc = confirm.GetComponent<Dialogcontroller>();

        //アイテムイメージをAnimalImageに代入
        AnimalImage =dc.itemImage;

        //スプライト化したAnimalImageをonclick()に設定したファイルの画像を代入
        AnimalImage.sprite = item.Item.GetIcon();
        Debug.Log(AnimalImage.sprite);
        Debug.Log(item.Item.GetIcon());

        //ダイアログテキストを表示
        dc.ShowDialog(item.Item.GetAnimalPrice() + "G" + "で購入しますか？");

        //PurchaseScore変数に、onclick()に設定したファイルの価格を代入
        PurchaseScore = item.Item.GetAnimalPrice();//引数名.関数名

        Debug.Log("AnimalPrice" + item.Item.GetAnimalPrice());

        //はいボタンが押されたときの動作   //ラムダ式を使うことで、関数内で関数を定義できる
        dc.YesButton.onClick.AddListener(() =>
        {
            //売り切れの表示
            item.OutOfStock();

            // 在庫を減らす
            Debug.Log(item.Item.animalId);
            m_stock[item.Item.animalId]--; // 在庫がなくなった時の処理はしていない。減らすだけ。
            string json = JsonUtility.ToJson(new Serialization<int, int>(m_stock));
            Debug.LogFormat("stock: {0}", json);
            PlayerPrefs.SetString("StockData", json);
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

            Debug.Log(item.Item.GetAnimalPrice() + "で購入しました");

            //YesNoPrefabを破壊
            Destroy(confirm);
        });
    }
}