using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopItemController : MonoBehaviour
{
    //選択する購入ボタン
    [SerializeField]
    private GameObject m_purchaseButton;
    //売り切れを表示するUI
    [SerializeField]
    private GameObject m_outOfStockUi;
    //PurchasingInformationを利用するための変数
    public PurchasingInformation Item;
    //どうぶつのプレハブを利用するために宣言
    public AnimalController ap;
    //背景画像
    [SerializeField]
    private GameObject AfterPurchaseimage;

    public void OutOfStock()
    {
        //売り切れを表示
        m_outOfStockUi.SetActive(true);
        //購入ボタンの非表示
        m_purchaseButton.SetActive(false);
        //背景画像を有効
        AfterPurchaseimage.SetActive(true);

    }

}