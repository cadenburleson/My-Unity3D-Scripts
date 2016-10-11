using UnityEngine;
using System;

[Serializable]
public class ManagerData {

	string managerName;
	float managerPrice;
	string managerDescription;

	// Constructors
	public ManagerData (string manager_name) {
		managerName = manager_name;
	}
	public ManagerData(string manager_name, float manager_price, string manager_description) {
		managerName = manager_name;
		managerPrice = manager_price;
		managerDescription = manager_description;
	}

	public string getName() {
		return managerName;
	}
	public void setName(string name){
		managerName = name;
	}

	public float getPriceVal() {
		return managerPrice;
	}
	public void setPriceVal(float newPriceVal) {
		managerPrice = newPriceVal;
		//		fileService.savePlayer (myPlayer);
	}

	public string getDescription() {
		return managerDescription;
	}
	public void setDescription(string newDescription) {
		managerDescription = newDescription;
		//		fileService.savePlayer (myPlayer);
	}

//	public void updateMoneyText () {
//		moneyText.text = money.ToString("C");
//		//		Debug.Log("update Money Text >> player.money = " + money);
//	}

}
