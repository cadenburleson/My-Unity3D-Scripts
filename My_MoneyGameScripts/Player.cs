using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public class Player { 

	public static float money = 0f;
//	private float money = 0f;
	[SerializeField]
	private Text moneyText;

//	void awake () { 
//		moneyText.text = money.ToString ("C");
//	}

	public void IncreaseMoneyBy(float amount) {
		money = money + amount;
//		money = getMoneyVal () + amount;
		moneyText.text = money.ToString ("C");
		Debug.Log ("You have Increased your Money by " + amount );
	}

	public void DecreaseMoneyBy(float amount){
		money = money - amount;
//		money = getMoneyVal () - amount;
		moneyText.text = money.ToString ("C");
		Debug.Log ("You have Decreased your Money by " + amount );
	}

	public float getMoneyVal() {
		return money;
	}

}
