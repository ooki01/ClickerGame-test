using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseController : MonoBehaviour
{
    [SerializeField] int m_price = 100;
    [SerializeField] Text m_caption;
    [SerializeField] GameObject m_dialogPrefab;

    void Start()
    {
        m_caption.text = m_price.ToString();
    }

    void Update()
    {
        
    }

    public void Purchase()
    {
        GameObject go = Instantiate(m_dialogPrefab, transform.GetComponentInParent<Canvas>().transform);
        DialogController dc = go.GetComponent<DialogController>();
        dc.ShowDialog(m_price.ToString() +"G"+ "で購入しますか？");
        dc.m_ok.onClick.AddListener(() =>
        {
            Debug.Log(m_price + "で購入しました");
            Destroy(go);
        });
    }
}
