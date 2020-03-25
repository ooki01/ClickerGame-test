using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public Button m_ok;
    public Button m_cancel;
    [SerializeField] Text m_message;

    void Start()
    {
        m_cancel.onClick.AddListener(() => { Destroy(gameObject);  });
        Debug.Log("gameObject" + gameObject);
    }
    
    void Update()
    {
        
    }

    public void ShowDialog(string message)
    {
        m_message.text = message;
        Debug.Log("text" + message);
    }
}
