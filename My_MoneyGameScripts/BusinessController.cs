using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using System.Runtime.Serialization.Formatters.Binary;

public class BusinessController : MonoBehaviour {

	public MoneyGameManager myMoneyGameManager;

	[SerializeField]
	private string bizName = "The name you want to call your business...";
	[SerializeField]
	private Text nameDisplayText;

	[SerializeField]
	private float bizCycleTime = 2.0f;
	public Text businessRateText;

	[SerializeField]
	private float bizCost = 0f;
	public Text buyBusinessCostText;

	[SerializeField]
	private int bizQuantityOwned = 0;
	public Text text_quantityOwned;

	[SerializeField]
	private float bizIncome = 0f;
	public Text incomeText;

	[SerializeField]
	private string bizId = "";

//	[SerializeField]
//	private float resetTimeForBusiness;
//	[SerializeField]
//	private float costMultiplier;

	[SerializeField]
	private Button workButton;
	[SerializeField]
	private Button buyBusinessButton;
	[SerializeField]
	private Slider timeTillBusinessIsBoughtSlider;

	[SerializeField]
	private AudioSource myAudio;

	private bool isTimerStarted = false;

	private FileService fileService;


	private Business myBusiness;

	void Start () {
		Debug.Log ("BizController-Start()");
		initBusiness ();
	}

	public void Update () {
				
		if (myBusiness.getCost() <= myMoneyGameManager.getMoneyVal()) {
			buyBusinessButton.interactable = true;
		}else {
			buyBusinessButton.interactable = false;
		}

		if (isTimerStarted == true) {
			timeTillBusinessIsBoughtSlider.value += Time.deltaTime;
			// LOOK AT THIS BELOW
			buyBusinessButton.interactable = false;
			workButton.interactable = false;
			// Timer is over
			if (timeTillBusinessIsBoughtSlider.value == myBusiness.getCycleTime() ) {
				isTimerStarted = false;
				workButton.interactable = true;
				timeTillBusinessIsBoughtSlider.value = 0;
				myMoneyGameManager.IncreaseMoney(myBusiness.getIncome());
				fileService.save (myBusiness);
				businessRateText.text = myBusiness.getCycleTime().ToString("00:00:00");
			}

		}


	}// end of update()

	public void initBusiness() {
		fileService = new FileService ();
		myBusiness = fileService.load (bizId);
		if (myBusiness == null) {
			Debug.Log ("init-No file existed; set the defaults...");
			// No file existed; set the defaults...
			myBusiness = new Business (bizId);
			myBusiness.setName (bizName);
			Debug.Log ("new business created with id of : "+bizId + " and a name of : "+bizName);
//			Debug.Log (bizId + "Name is:" + bizName);
			myBusiness.setIncome (bizIncome);
			myBusiness.setQuantityOwned (bizQuantityOwned);
			myBusiness.setCost (bizCost);
			myBusiness.setCycleTime (bizCycleTime);
			Debug.Log (bizName + " -Income is : " + bizIncome);
			Debug.Log (bizName + " -Quantity owned is " + bizQuantityOwned);
			Debug.Log (bizName + " -Cost is: " + bizCost);
			Debug.Log (bizName + " -Cycle time is : " + bizCycleTime);
		} else {
			Debug.Log ("init-myBiznuss was not null");
		}
		updateText ();
		Debug.Log ("Business " + myBusiness.getId() + " Has been initialized()... ");

		int initCount = 0;
		initCount++;

		Debug.Log ("initCount : " + initCount);
	}

	private void updateText() {
		//		incomeText.text = bizIncome.ToString ("C");
		incomeText.text = myBusiness.getIncome().ToString ("C");
		//		text_quantityOwned.text = bizQuantityOwned.ToString("D");
		text_quantityOwned.text = myBusiness.getQuantityOwned().ToString("D");
		//		buyBusinessCostText.text = bizCost.ToString("C");
		buyBusinessCostText.text = myBusiness.getCost().ToString("C");
		//		nameDisplayText.text = bizName;
		nameDisplayText.text = myBusiness.getName();
		//		timeTillBusinessIsBoughtSlider.maxValue = bizCycleTime;
		timeTillBusinessIsBoughtSlider.maxValue = myBusiness.getCycleTime();
		//		timeTillBusinessIsBoughtSlider.value = 0;
		text_quantityOwned.text = myBusiness.getQuantityOwned().ToString("D");

		Debug.Log ("business " + myBusiness.getName() +  " text updated.");
	}
		
	public void WorkBusiness() {
		isTimerStarted = !isTimerStarted;
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

		fileService.save (myBusiness);
		updateText ();
	} // end of buybusiness


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
