using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[CreateAssetMenu(menuName = "PurchaseingInformation", fileName = "CreatePurchase")]
public class PurchasingInformation : ScriptableObject
{
	public enum KindofAnimal
	{
		Animal,
		price
	}

	//どうぶつの種類
	[SerializeField]
	private KindofAnimal kindofAnimal;

	//どうぶつのアイコン
	[SerializeField]
	private Sprite icon;

	//どうぶつの名前
	[SerializeField]
	private string AnimalName;

	//どうぶつの価格
	[SerializeField]
	private int AnimalPrice;


	public KindofAnimal GetKindofAnimal()
	{
		return kindofAnimal;
	}

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

} // class ParameterTable
