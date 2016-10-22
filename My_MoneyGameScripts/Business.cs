using System;
using System.Configuration;
using UnityEngine;

[Serializable]
public class Business {
	
	string businessId = "";

	string businessName = "The name you want to call your business...";
	// !! This doesn't seem like it should be in business
	// !! Looks like it should be well? IDK now FUCK.
	int businessQuantityOwned;

	float businessCycleTime;
	float businessCost;
	float businessIncome;
	float businessBaseCost;
	float businessBaseIncome;

	bool isManagerWorking = false;

	public Business(){
	}
	// Constructors
	public Business(string newId) {
		businessId = newId;
	}

	public bool getManagerWorkingStatus(){
		return isManagerWorking;
	}
	public void setManagerWorkingStatus(bool new_Status){
		isManagerWorking = new_Status;
	}
		

	//	*** ID ***
	public string getId() {
		return businessId;
	}
	public void setId(string newId) {
		businessId = newId;
	}
			

	//	*** NAME ***
	public string getName() {
		return businessName;
	}
	public void setName(string newBusinessName){
		businessName = newBusinessName;
	}

	//	*** CYCLE TIME ***
	public float getCycleTime() {
		return businessCycleTime;
	}
	public void setCycleTime(float newCycleTime) {
		businessCycleTime = newCycleTime;
	}

	//	*** COST ***
	public float getCost() {
		return businessCost;
	}
	public void setCost(float cost) {
		businessCost = cost;
	}

	//	*** BASE COST ***
	public float getBaseCost(){
		return businessBaseCost;
	}
	public void setBaseCost(float cost) {
		businessBaseCost = cost;
	}

	//	*** QUANTITY OWNED ***
	public int getQuantityOwned(){
		return businessQuantityOwned;
	}
	public void setQuantityOwned(int quantityOwned) {
		businessQuantityOwned = quantityOwned;
	}

	//	*** INCOME ***
	public float getIncome() {
		return businessIncome;
	}
	public void setIncome(float income){
		businessIncome = income;
	}

	//	*** BASE INCOME ***
	public float getBaseIncome() {
		return businessBaseIncome;
	}
	public void setBaseIncome(float income) {
		businessBaseIncome = income;
	}
		
}

