using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onClick()
    {
        //GameScene2を読み込む
        SceneManager.LoadSceneAsync("GameScene2");
    }
}