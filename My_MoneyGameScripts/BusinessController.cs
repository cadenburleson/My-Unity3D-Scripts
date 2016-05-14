using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using System.Runtime.Serialization.Formatters.Binary;

public class BusinessController : MonoBehaviour {

	public MoneyGameManager myMoneyGameManager;


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
	private Text buyBusinessCostText;
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
			Debug.Log ("No file existed, we created a business with the values your chose for you :) ");
		}

		//goes away (only if business after load == null
		incomeText.text = bizIncome.ToString ("C");
		text_quantityOwned.text = bizQuantityOwned.ToString("D");
		buyBusinessCostText.text = bizCost.ToString("C");

		nameDisplayText.text = bizName;

//		bizSlider.maxValue = bizCycleTime;
		bizSlider.maxValue = myBusiness.getCycleTime();

		bizSlider.value = 0;
		//		quantityOwned = PlayerPrefs.GetInt ("myQuantityOwned");
		text_quantityOwned.text = myBusiness.getQuantityOwned().ToString("D");

		Debug.Log ("Business " + myBusiness.getId() + " Has been initialized()... ");

	}
		
	public void Update () {

		if ( myMoneyGameManager.getMoneyVal () >= myBusiness.getCost() ) {
			buyBusinessButton.interactable = true;
		} else {
			buyBusinessButton.interactable = false;
		}


		if (isTimerStarted == true) {

			bizSlider.value +=  Time.deltaTime;
			bizCycleTime -= Time.deltaTime;
			text_bizCycleTime.text = bizCycleTime.ToString("00:00:00");
							
			// LOOK AT THIS BELOW
			buyBusinessButton.interactable = false;
			workButton.interactable = false;

			if (bizCycleTime <= 0) {

				Debug.Log ("The bizCycle Time is suposed to be less than or equal to mybiz.getcycletime() ");
				Debug.Log ("biz cycle time is : " + bizCycleTime + " The mybiz.getCycleTime() is : " + myBusiness.getCycleTime());

				bizCycleTime = myBusiness.getCycleTime ();
				bizSlider.value = 0;

				workButton.interactable = true;

				myMoneyGameManager.IncreaseMoney ( myBusiness.getIncome() );
				incomeText.text = myBusiness.getIncome().ToString("C");
				text_bizCycleTime.text = myBusiness.getCycleTime().ToString("00:00:00");

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
		//		Player.bought(myBusiness);
		myMoneyGameManager.DecreaseMoney( myBusiness.getCost());
		int qty = myBusiness.getQuantityOwned ();
		qty++;
		myBusiness.setQuantityOwned ( qty );
		text_quantityOwned.text = myBusiness.getQuantityOwned().ToString("D");

		float income = myBusiness.getIncome (); 
		income = income + (Mathf.Log(bizIncome));
		if (income >= myBusiness.getCost()) {
			Debug.Log ("You Are Making More than this building costs, SOMETHING MUST BE WRONG!");
			myBusiness.setCost ( myBusiness.getCost() * 2);
			buyBusinessCostText.text = myBusiness.getCost ().ToString ("C");

		}

		Debug.Log (income);
		myBusiness.setIncome( income );

		fileService.saveBusiness (myBusiness);

		Debug.Log ("You bought business");
		//		updateText ();

	} // end of buybusiness


	public void deleteBusiness () {
		fileService.deleteBusinessById (bizId);
		Debug.Log ("You have deleted your save");
	}





}