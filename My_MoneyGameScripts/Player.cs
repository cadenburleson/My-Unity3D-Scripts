using UnityEngine;
//using System.Collections;
//using UnityEngine.UI;

public static class Player {

	private static float cash;


	public static float bought(Business bizToBuy) {
		cash = cash - bizToBuy.getCost ();
		Debug.Log ("Player has bought" + bizToBuy.getName() + " and was charged an amount of : $" + bizToBuy.getCost());
		return cash;
	} 


//	private float money;
//
//
//
//	public static float getPlayersMoney() {
//		return this.money;
//	}

}
