using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Dialogcontroller : MonoBehaviour
{
    //はいボタン
    public Button YesButton;
    //いいえボタン
    public Button NoButton;
    //説明文テキスト
    [SerializeField] Text caption;
    //インスペクタで設定するための変数
    public Image itemImage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void No()
    {
        Destroy(gameObject);
    }

    public void ShowDialog(string message)
    {
        caption.text = message;
    }
}
