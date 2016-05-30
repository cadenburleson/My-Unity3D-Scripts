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


			myBusiness.setBaseCost (bizCost);

			myBusiness.setBaseIncome (bizIncome);

			Debug.Log ("NO BUSINESS FILE EXISTED, we created a business with the values your chose for you :) ");
		} else {
			Debug.Log ("your business was NOT null");
		}
		nameDisplayText.text = myBusiness.getName ();
		text_quantityOwned.text = myBusiness.getQuantityOwned ().ToString ("d");

		incomeText.text = myBusiness.getIncome ().ToString ("c");
		businessCostText.text = myBusiness.getCost ().ToString ("c");

		bizSlider.maxValue = myBusiness.getCycleTime();
		bizSlider.value = 0;

	}//End Of Start
		

		
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

//			text_bizCycleTime.text = bizCycleTime.ToString("00:00:00");
			// LOOK AT THIS BELOW
			buyBusinessButton.interactable = false;
			workButton.interactable = false;

			if (bizCycleTime <= 0) {
				Debug.Log ("The bizCycle Time (" + bizCycleTime + ") is suposed to be <= mybiz.getcycletime() (" + myBusiness.getCycleTime() + ")." );
				bizSlider.value = 0;
				// resets the cycle time
				bizCycleTime = myBusiness.getCycleTime ();
				// this may not be necessary
				bizSlider.maxValue = bizCycleTime;
			
				workButton.interactable = true;

				// makes sure that you don't multiply by zero therefor making your value zero always
				if (myBusiness.getQuantityOwned() == 0) {
					myPlayer.IncreaseMoneyBy (myBusiness.getIncome());
//					myPlayer.IncreaseMoneyBy (myBusiness.getBaseIncome ());
				} else {
					myPlayer.IncreaseMoneyBy (myBusiness.getIncome() * myBusiness.getQuantityOwned());
//					myPlayer.IncreaseMoneyBy (myBusiness.getBaseIncome() * myBusiness.getQuantityOwned());
				}

				isTimerStarted = false;
				fileService.saveBusiness (myBusiness);
				Debug.Log ("Timer Has Been Stopped.");

			}

//			text_bizCycleTime.text = myBusiness.getCycleTime ().ToString ("g");
			text_bizCycleTime.text = bizCycleTime.ToString("g");

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

		// SETS INCOME
		myBusiness.setIncome(myBusiness.getBaseIncome() * myBusiness.getQuantityOwned());
		incomeText.text = myBusiness.getIncome ().ToString ("C");
		Debug.Log ("baseincome = " + myBusiness.getBaseIncome() + "getincome = " + myBusiness.getIncome());

		// SETS COST
		myBusiness.setCost ( Mathf.Pow(myBusiness.getBaseCost() * 1.07f, myBusiness.getQuantityOwned()) );
		businessCostText.text = myBusiness.getCost().ToString("C");
		Debug.Log ("basecost = " + myBusiness.getBaseIncome() + "getcost = " + myBusiness.getIncome());

		fileService.saveBusiness (myBusiness);

		Debug.Log ("You bought one more building of : " + myBusiness.getName() + "You now have : " + myBusiness.getQuantityOwned() );

	} // end of buybusiness


	public void deleteBusiness () {
//		fileService.deleteBusinessById (bizId);
		fileService.deleteBusinessById (myBusiness.getId());
		Debug.Log ("You have deleted your save");

	}


//	void OnApplicationQuit() {
//		fileService.saveBusiness (myBusiness);
//	}


}