using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopDataBase", menuName = "CreateShopDataBase")]
public class ShopDataBase : ScriptableObject
{

    [SerializeField]
    private List<PurchasingInformation> ProductLists = new List<PurchasingInformation>();

    //　商品リストを返す
    public List<PurchasingInformation> GetProductLists()
    {
        return ProductLists;
    }
}