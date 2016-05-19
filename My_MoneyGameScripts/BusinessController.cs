using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

using System.Runtime.Serialization.Formatters.Binary;

public class BusinessController : MonoBehaviour {

	[SerializeField]
	private Player myPlayer;

	// ID
	[SerializeField]
	private string bizId = "";
	// NAME
	[SerializeField]
	private string bizName = "The name you want to call your business...";
	[SerializeField]
	private Text nameDisplayText;

	// CYCLE TIME
	[SerializeField]
	private float bizCycleTime = 0.0f;
	//	[SerializeField]
	//	private Text businessRateText;
	[SerializeField]
	private Text text_bizCycleTime;
	[SerializeField]
	private Slider bizSlider;

	// COST
	[SerializeField]
	private float bizCost = 0f;
	[SerializeField]
	private Text businessCostText;
	// QUANTITY OWNED
	//	[SerializeField]
	private int bizQuantityOwned = 0;
	[SerializeField]
	private Text text_quantityOwned;
	// INCOME
	[SerializeField]
	private float bizIncome = 0f;
	[SerializeField]
	private Text incomeText;


	[SerializeField]
	private Button workButton;
	[SerializeField]
	private Button buyBusinessButton;


	[SerializeField]
	private AudioSource myAudio;

	public bool isTimerStarted = false;
	private FileService fileService;
	private Business myBusiness;

	void Start () {

		Debug.Log ("Start()");
		initBusiness ();
	}

	public void initBusiness() {

		fileService = new FileService ();
		myBusiness = fileService.loadBusinessById (bizId);

		if (myBusiness == null) {
			// No file existed; set the defaults...
			myBusiness = new Business (bizId);
			myBusiness.setIncome (bizIncome);
			myBusiness.setQuantityOwned (bizQuantityOwned);
			myBusiness.setCost (bizCost);
			myBusiness.setName (bizName);
			myBusiness.setCycleTime (bizCycleTime);
			Debug.Log ("No business file existed, we created a business with the values your chose for you :) ");
		}

		//goes away (only if business after load == null
		incomeText.text = bizIncome.ToString ("C");
		text_quantityOwned.text = bizQuantityOwned.ToString("D");
		businessCostText.text = bizCost.ToString("C");
		nameDisplayText.text = bizName;

		bizSlider.maxValue = bizCycleTime;
		bizSlider.value = 0;
		Debug.Log ("Business " + myBusiness.getId() + " Has been initialized()... ");

	}
		
	public void Update () {

		// if the business costs more than you can afford then disable the buy button
		if (myBusiness.getCost() > myPlayer.getMoneyVal()) {
			buyBusinessButton.interactable = false;
		}else{
			buyBusinessButton.interactable = true;
		}
			
		if (isTimerStarted == true) {
			// move the slider
			bizSlider.value +=  Time.deltaTime;
			bizCycleTime -= Time.deltaTime;

			text_bizCycleTime.text = bizCycleTime.ToString("00:00:00");
			// LOOK AT THIS BELOW
			buyBusinessButton.interactable = false;
			workButton.interactable = false;

			if (bizCycleTime <= 0) {
				Debug.Log ("The bizCycle Time is suposed to be less than or equal to mybiz.getcycletime() ");
				Debug.Log ("biz cycle time is : " + bizCycleTime + " The myBusiness.getCycleTime() is : " + myBusiness.getCycleTime());

				bizSlider.value = 0;
				// resets the cycle time
				bizCycleTime = myBusiness.getCycleTime ();
				bizSlider.maxValue = bizCycleTime;
//				bizSlider.maxValue = myBusiness.getCycleTime();

				workButton.interactable = true;

				// makes sure that you don't multiply by zero therefor making your value zero always
				if (myBusiness.getQuantityOwned() == 0) {
					myPlayer.IncreaseMoneyBy (myBusiness.getIncome());
				} else {
					myPlayer.IncreaseMoneyBy (myBusiness.getIncome() * myBusiness.getQuantityOwned());
				}
					
				fileService.saveBusiness (myBusiness);
				isTimerStarted = false;
				Debug.Log ("Timer Has Been Stopped.");

			}

		}
			
	} // end of update 


	public void WorkBusiness() {
		isTimerStarted = !isTimerStarted;
		Debug.Log ("timer is : " + isTimerStarted);
	}


	public void BuyBusiness() {
		myAudio.Play ();
		myPlayer.DecreaseMoneyBy( myBusiness.getCost() );
			
		// Updates the quantity owned both data and text
		int qty = myBusiness.getQuantityOwned();
		qty++;

		myBusiness.setQuantityOwned ( qty );
		text_quantityOwned.text = myBusiness.getQuantityOwned().ToString("D");


		Debug.Log("bizCost local = " + bizCost + "myBusiness.getCost() : " + myBusiness.getCost());
		// Business COST update
		myBusiness.setCost ( myBusiness.getCost() * Mathf.Pow(1.07f, myBusiness.getQuantityOwned() ) ); 
		businessCostText.text = myBusiness.getCost().ToString("C");

		// Business Income update
		Debug.Log("bizIncome local = " + bizIncome + "myBusiness.getIncome() : " + myBusiness.getIncome());

		// Maybe make a new var in the business class called BaseIncome instead of using bizIncome
		// And have the BaseIncome Never change after init()
		myBusiness.setIncome ( bizIncome * myBusiness.getQuantityOwned () );
		incomeText.text = myBusiness.getIncome().ToString("C");

		fileService.saveBusiness (myBusiness);

		Debug.Log ("You bought one more building of : " + myBusiness.getName() + "You now have : " + myBusiness.getQuantityOwned() );

	} // end of buybusiness


	public void deleteBusiness () {
		fileService.deleteBusinessById (bizId);
		Debug.Log ("You have deleted your save");
	}


}