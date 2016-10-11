using UnityEngine;
using UnityEngine.UI;

public class BusinessController : MonoBehaviour {

//	float playersMoney; // private redundant this is the default modifier

	// ID
	[SerializeField]
	string bizId = "";

	// NAME
	[SerializeField]
	string bizName = "The name you want to call your business...";
	[SerializeField]
	Text text_NameDisplay; // never assigned

	// CYCLE TIME
	[SerializeField]
	float bizCycleTime;
	[SerializeField]
	Text text_bizCycleTime; // never assigned
	[SerializeField]
	Slider bizSlider; // never assigned

	// COST
	[SerializeField]
	float bizCost;
	[SerializeField]
	Text text_BusinessCost; // never assigned

	// QUANTITY OWNED
	[SerializeField]
	int bizQuantityOwned = 0; // never assigned
	[SerializeField]
	Text text_quantityOwned; // never assigned

	// INCOME
	[SerializeField]
	float bizIncome = 1f; //Make it to where this can't be zero.
	[SerializeField]
	Text text_Income; // never assigned

	//Buttons
	[SerializeField]
	Button button_WorkBusiness; // never assigned
	[SerializeField]
	Button button_BuyBusiness;

	[SerializeField]
	AudioSource myAudio; // never assigned

	public bool isTimerStarted;

	[SerializeField]
	bool isManagerOwned = false;
	[SerializeField]
	Button button_HireManager;

	[SerializeField]
	Player myPlayer;

	[SerializeField]
	Text baseIncome_Text;

	FileService fileService;

	Business myBusiness;

	void Start () {
		//		Debug.Log ("BusinessController // Start()");
		//		Debug.Log ("BusinessController // Application data location: " + Application.persistentDataPath);

		myPlayer = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
		fileService = new FileService ();
		myBusiness = fileService.loadBusinessById (bizId) as Business;

		if (myBusiness == null) {
			/*
			 You have not saved a file yet
			 so we'll create a temporary business with the variable values that
			 you provide in the inspector.
			*/
			myBusiness = new Business (bizId);
			myBusiness.setQuantityOwned (bizQuantityOwned);
			myBusiness.setName (bizName);
			myBusiness.setCycleTime (bizCycleTime);
			myBusiness.setCost (bizCost);
			myBusiness.setIncome (bizIncome);
			myBusiness.setBaseCost (bizCost);
			myBusiness.setBaseIncome (bizIncome);

			myBusiness.setManager (isManagerOwned);

			Debug.Log ("BusinessController // NO BUSINESS FILE EXISTED, we created a business with the values your chose for you :) ");
			Debug.Log (string.Format ("Business init () " + "Business Name: {0},  Business Cycle Time: {1}, Business Cost: {2}", myBusiness.getName(), myBusiness.getCycleTime(), myBusiness.getCost() ) );
		} else {
			Debug.Log ("BusinessController // your business was NOT null");
			Debug.Log (string.Format ("Business Name: {0},  Business Cycle Time: {1}, Business Cost: {2} Business Income: {3} ", myBusiness.getName(), myBusiness.getCycleTime(), myBusiness.getCost(), myBusiness.getIncome() ) );
		}
		text_NameDisplay.text = myBusiness.getName ();
		text_Income.text = myBusiness.getIncome ().ToString ("c");
		text_BusinessCost.text = myBusiness.getCost ().ToString ("c");
		text_quantityOwned.text = "qt : " + myBusiness.getQuantityOwned ().ToString ("d");
		bizSlider.maxValue = myBusiness.getCycleTime();
		bizSlider.value = 0;
	} //End Of Start


	public void Update () {

		// Put a manager hire button here.
//		button_WorkBusiness.interactable = false;

		if (Input.GetKeyDown(KeyCode.B)) {
			Debug.Log (myBusiness.getName() + " has a manager = " + myBusiness.getManager());
		}

		baseIncome_Text.text = myBusiness.getBaseIncome ().ToString();
		checkIfYouCanAffordBusiness();

		if (myBusiness.getManager () == true) {
			//			if (isManagerOwned == true) { 

			button_HireManager.interactable = false;

			for (int x = 0; x <= bizCycleTime; x++) {
				increaseSlider ();
				if (bizCycleTime <= 0) {
					resetSlider ();
					float playersMoney = myBusiness.getBaseIncome () * myBusiness.getQuantityOwned ();
					payPlayer (playersMoney);
					myPlayer.updateMoneyText ();
					//Debug.Log ("Reset Slider in Manager stuff");
				}
				text_bizCycleTime.text = bizCycleTime.ToString ("g");
			}
		} else {
			Debug.Log (myBusiness.getName() + "doesn't have a manager yet.");
		}

		// Basically this is the Work Business function
		if (isTimerStarted) {
			increaseSlider();
			button_WorkBusiness.interactable = false;
			// makes sure that you don't multiply by zero therefor making your value zero always
			if (bizCycleTime <= 0) {
				resetSlider ();
				button_WorkBusiness.interactable = true;
				float playersMoney = myBusiness.getBaseIncome() * myBusiness.getQuantityOwned();
				Debug.Log ("Work Button >> Players Money = " + playersMoney);
				payPlayer(playersMoney);
				myPlayer.updateMoneyText ();
				isTimerStarted = false;
				fileService.saveBusiness (myBusiness);
			}
			text_bizCycleTime.text = bizCycleTime.ToString("g");
		}// End Of Timer Started

	} // End Of Update

	public void hireManager() {
		myBusiness.setManager (true);
		fileService.saveBusiness (myBusiness);
		isManagerOwned = true;
	}
		
	void updateIncomeText() {
		text_Income.text = myBusiness.getIncome ().ToString ("C");
	}

	void updateCostText(){
		text_BusinessCost.text = myBusiness.getCost ().ToString ("c");
	}

	void updateQuantityText(){
		text_quantityOwned.text = "qt : " + myBusiness.getQuantityOwned ().ToString ("d");
	}

	void payPlayer(float amount) {
		float playerMoney = myPlayer.getMoneyVal ();
		playerMoney += amount;
		myPlayer.setMoneyVal (playerMoney);
		fileService.savePlayer (myPlayer);
//		Debug.Log("payPlayer >> players Money = " + playerMoney);
	}

	void increasePlayersMoneyBy (float amount) {
		float playersMoney = myPlayer.getMoneyVal ();
		playersMoney = amount;
		myPlayer.setMoneyVal (playersMoney);
		fileService.savePlayer (myPlayer);
	}


	void takePlayersMoney(float amount){
		float playerMoney = myPlayer.getMoneyVal();
		playerMoney -= amount;
		myPlayer.setMoneyVal (playerMoney);
		fileService.savePlayer (myPlayer);

	}

	void increaseSlider(){
		bizSlider.value +=  Time.deltaTime;
		bizCycleTime -= Time.deltaTime;
	}

	void resetSlider(){
		bizSlider.value = 0;
		bizCycleTime = myBusiness.getCycleTime ();
	}
		
	void checkIfYouCanAffordBusiness(){
		
		if ( myBusiness.getCost() > myPlayer.getMoneyVal() ) {
			button_BuyBusiness.interactable = false;
		}else{
			button_BuyBusiness.interactable = true;
		}
			

	}

	public void WorkBusiness() {
		isTimerStarted = !isTimerStarted;
		Debug.Log ("BusinessController // timer is : " + isTimerStarted);
	}

	public void BuyBusiness() {
		myAudio.Play ();
		takePlayersMoney (bizCost);

		// Updates the quantity owned both data and text
		int qty = myBusiness.getQuantityOwned();
		qty++;
		myBusiness.setQuantityOwned ( qty );
		string quantityOwned = myBusiness.getQuantityOwned().ToString("d");
		text_quantityOwned.text = "qt : " + quantityOwned;

		myBusiness.setIncome (myBusiness.getBaseIncome() * myBusiness.getQuantityOwned());
		text_Income.text = myBusiness.getIncome ().ToString ("C");

		// SETS COST / PRICE
		bizCost = Mathf.Pow ( 1.07f, myBusiness.getQuantityOwned() );
		bizCost = bizCost * myBusiness.getBaseCost ();
		myBusiness.setCost (bizCost);

		text_BusinessCost.text = myBusiness.getCost().ToString("C");

		myPlayer.updateMoneyText ();

		fileService.saveBusiness(myBusiness);
	} // end of buybusiness

	public void deleteBusiness () {
		fileService.deleteBusinessById (bizId);
//		fileService.delete (myBusiness);
		Debug.Log ("BusinessController // You have deleted your save");

	}

//	void OnApplicationQuit() {
//		fileService.saveBusiness (myBusiness);
//	}


}
