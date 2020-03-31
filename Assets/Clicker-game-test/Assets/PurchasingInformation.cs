using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[CreateAssetMenu(menuName = "PurchaseingInformation", fileName = "CreatePurchase")]
public class PurchasingInformation : ScriptableObject
{

    //どうぶつのアイコン
    [SerializeField]
    private Sprite icon;
    //どうぶつの名前
    [SerializeField]
    private string AnimalName;
    //どうぶつの価格
    [SerializeField]
    private int AnimalPrice;
    //どうぶつの価格
    [SerializeField]
    //どうぶつの在庫
    public int animalId;
    //どうぶつのプレハブ
    public GameObject animal_prefab;

    public Sprite GetIcon()
    {
        return icon;
    }

    public string GetAnimalName()
    {
        return AnimalName;
    }

    public int GetAnimalPrice()
    {
        return AnimalPrice;
    }

    public int GetanimalId()
    {
        return animalId;
    }

    public GameObject Getanimal_prefab()
    {
        return animal_prefab;
    }
} // class ParameterTable
