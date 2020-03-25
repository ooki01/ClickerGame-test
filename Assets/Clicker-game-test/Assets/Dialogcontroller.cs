using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Dialogcontroller : MonoBehaviour { 

        //はいボタン
        public Button YesButton;
        //いいえボタン
        public Button NoButton;
        //説明文テキスト
        [SerializeField] Text caption;
        //イメージ画像
        [SerializeField]
        Sprite ModelImage;
        public Image AnimalImage;

    // Start is called before the first frame update
    void Start()
    {
        AnimalImage = GetComponent<Image>();
        AnimalImage.sprite = ModelImage;

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
        Debug.Log("text" + message);
    }

    public void ShowImage(PurchasingInformation PurchaseProcessing)
    {
        PurchaseProcessing.GetIcon();
    }
}
