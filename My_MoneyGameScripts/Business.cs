using System;

[Serializable]
public class Business  {
	private string id = "";
	private string name = "The name you want to call your business...";
	private float cycleTime = 0f;
	private float cost = 0f;
	private int quantityOwned = 0;
	private float income = 0f;

//	public float thisDickSize { get; set;}

//	private float resetTimeForBusiness;
	public Business(string id) {
		this.id = id;
	}
//	*** ID ***
	public string getId() {
		return this.id;
	}
	public void setId(string id) {
		this.id = id;
	}
//	*** NAME ***
	public string getName() {
		return this.name;
	}
	public void setName(string businessName){
		this.name = businessName;
	}
//	*** CYCLE TIME ***
	public float getCycleTime() {
		return this.cycleTime;
	}
	public void setCycleTime(float cycleTime) {
		this.cycleTime = cycleTime;
	}
//	*** COST ***
	public float getCost(){
		return this.cost;
	}
	public void setCost(float cost){
		this.cost = cost;
	}
//	*** QUANTITY OWNED ***
	public int getQuantityOwned(){
		return this.quantityOwned;
	}
	public void setQuantityOwned(int quantityOwned){
		this.quantityOwned = quantityOwned;
	}		
//	*** INCOME ***
	public float getIncome() {
		return this.income;
	}
	public void setIncome(float income){
		this.income = income;
	}


}
