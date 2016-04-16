using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using System.Runtime.Serialization.Formatters.Binary; 

public class BusinessController : MonoBehaviour {

	public MoneyGameManager myMoneyGameManager;

	[SerializeField]
	private string bizName = "The name you want to call your business...";
	[SerializeField]
	private float  bizCycleTime = 2.0f;
	// Never change
	[SerializeField]
	private float resetTimeForBusiness;
	[SerializeField]
	private float bizCost = 0f;

	[SerializeField]
	private float costMultiplier;

	[SerializeField]
	private int bizQuantityOwned = 0;
	[SerializeField]
	private float bizIncome = 0f;

	[SerializeField]
	private string bizId = "";

	[SerializeField]
	private Text nameDisplayText;

	//Make these private serializable fields?
	public Text incomeText;
	public Text text_quantityOwned;
	public Text businessRateText;
	public Text buyBusinessCostText;
	public Button workButton;
	public Button buyBusinessButton;
	public Slider timeTillBusinessIsBoughtSlider;

	public bool isTimerStarted = false;

	public Business myBusiness;

	private FileService fileService;

	// public or private FileService fileService;

	void Start () {
		Debug.Log ("Start()");
		initBusiness ();
	}
		

		
	public void Update () {
		if (isTimerStarted == true) {
			
			timeTillBusinessIsBoughtSlider.value +=  Time.deltaTime;

			// LOOK AT THIS BELOW
			buyBusinessButton.interactable = false;
			workButton.interactable = false;

			if (timeTillBusinessIsBoughtSlider.value == myBusiness.getCycleTime() ) {

				isTimerStarted = false;

				buyBusinessButton.interactable = true;
				workButton.interactable = true;
				timeTillBusinessIsBoughtSlider.value = resetTimeForBusiness;

				myMoneyGameManager.IncreaseMoney ( myBusiness.getIncome() );
				incomeText.text = myBusiness.getIncome().ToString("C");

				Debug.Log ("Timer Has Been Stopped.");

				fileService.save (myBusiness);

				businessRateText.text = myBusiness.getCycleTime().ToString("00:00:00");

			}

		}


	}


	public void initBusiness() {

		fileService = new FileService ();
		myBusiness = fileService.load (bizId);

		if (myBusiness == null) {

			// No file existed; set the defaults...
			myBusiness = new Business (bizId);
			myBusiness.setIncome (bizIncome);
			myBusiness.setQuantityOwned (bizQuantityOwned);
			myBusiness.setCost (bizCost);
			myBusiness.setName (bizName);
			myBusiness.setCycleTime (bizCycleTime);
		}

		//goes away (only if business after load == null
		incomeText.text = bizIncome.ToString ("C");
		text_quantityOwned.text = bizQuantityOwned.ToString("D");
		buyBusinessCostText.text = bizCost.ToString("C");

		nameDisplayText.text = bizName;

		timeTillBusinessIsBoughtSlider.maxValue = bizCycleTime;
		timeTillBusinessIsBoughtSlider.value = 0;
		//		quantityOwned = PlayerPrefs.GetInt ("myQuantityOwned");
		text_quantityOwned.text = myBusiness.getQuantityOwned().ToString("D");

		Debug.Log ("Business " + myBusiness.getId() + " Has been initialized()... ");

	}

	public void WorkBusiness() {
		//timeForBusiness = timeForBusiness;
		isTimerStarted = !isTimerStarted;


	}
		
	public void BuyBusiness() {
		if ( MoneyGameManager.money <= myBusiness.getCost() ) {
			buyBusinessButton.interactable = false;
		} else {
			buyBusinessButton.interactable = true;
		}
		myMoneyGameManager.DecreaseMoney( myBusiness.getCost() );

		int qty = myBusiness.getQuantityOwned ();
		qty++;
		myBusiness.setQuantityOwned ( qty );

		text_quantityOwned.text = myBusiness.getQuantityOwned().ToString("D");

//		float percentMultiplier = income * 0.02f;
//		Debug.Log ("%" + percentMultiplier);

		float income = myBusiness.getIncome ();
		income += income;
		myBusiness.setIncome( income );

		fileService.save (myBusiness);
	
		incomeText.text = myBusiness.getIncome().ToString("C");
	}


	public void deleteBusiness () {
		fileService.delete (bizId);
	}

//	public void SaveBusinessStats(){
//		PlayerPrefs.Save ();
//		Debug.Log ("You Have Deleted All Your Progress!");
//	}
//
//	public void DeleteBusinessStats(){
//		PlayerPrefs.DeleteAll ();
//		Debug.Log ("You Have Deleted All Your Progress!");
//
//	}


}
