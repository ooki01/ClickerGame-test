using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOff : MonoBehaviour
{
    Dictionary<int, int> off_stock;
    //購入ボタン
    [SerializeField]
    private Button purchaseButton;
    //購入テキスト
    [SerializeField]
    private Text purchaseText;
    
    // Start is called before the first frame update
    void Start()
    {
        string json = PlayerPrefs.GetString("StockData");
        Debug.LogFormat("json: {0}", json);
        
        off_stock = JsonUtility.FromJson<Serialization<int, int>>(json).ToDictionary();
    }
    
    // Update is called once per frame
    void Update()
    {

    }
    
    public void NoPurchase(PurchasingInformation noPuruchase)
    {
        Debug.Log("qqqq");
        Debug.Log(noPuruchase.animalId);
        Debug.Log(off_stock);
        Debug.Log(off_stock[noPuruchase.animalId]);
        if (off_stock[noPuruchase.animalId] == 0)
        {
            Debug.Log("aaa");
        }
    }
}
