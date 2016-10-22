using UnityEngine;
using UnityEngine.UI;

public class ManagerController : MonoBehaviour {

	public ManagerData myManager;

	[SerializeField]
	string managerName;
	[SerializeField]
	Text nameText;

	[SerializeField]
	float managerPrice = 0f;
	[SerializeField]
	Text priceText;

	[SerializeField]
	string managerDescription;
	[SerializeField]
	Text descriptionText;


	[SerializeField]
	Button button_Hire;

	Player myPlayer;

	FileService fileService;

	void Awake () {
		Debug.Log ("ManagerController >> manager hired status = " + myManager.getHiredStatus()); 
	}

//	 Use this for initialization
	void Start () {

		myPlayer = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();

		fileService = new FileService ();
		myManager = fileService.loadManager (managerName) as ManagerData;

		if (myManager == null) {
			/*
			 You have not saved a file yet
			 so we'll create a temporary business with the variable values that
			 you provide in the inspector.
			*/
			myManager = new ManagerData (managerName);

			myManager.setName (managerName);
			myManager.setPriceVal (managerPrice);
			myManager.setDescription (managerDescription);

//			myManager.setHiredStatus (myManager.getHiredStatus());

			updateText ();	
			fileService.saveManager (myManager);
			Debug.Log (string.Format ("Manager init () " + "Manager Name: {0},  Manager Price: {1}, Manager Description: {2}", myManager.getName(), myManager.getPriceVal(), myManager.getDescription() ) );
		}else {
			Debug.Log ("Manager // your manager was NOT null");
			Debug.Log (string.Format ("Manager Name: {0},  Manager Price: {1}, Manager Description: {2}", myManager.getName(), myManager.getPriceVal(), myManager.getDescription()));
		}
		updateText ();
		Debug.Log ("ManagerController >> manager hired status = " + myManager.getHiredStatus()); 
	}
		

	void Update () {

		// If manager has NOT been hired/purchased
		if (myManager.getHiredStatus () == false) {
			//check if you can afford one.
			if (myManager.getPriceVal () > myPlayer.getMoneyVal ()) {
				button_Hire.interactable = false;
			} else {
				button_Hire.interactable = true;
			}

		} else {
			// Button OFF
			button_Hire.interactable = false;
		}

			
	}

	void updateText() {
		nameText.text = myManager.getName ();
		priceText.text = myManager.getPriceVal ().ToString ("c");
		descriptionText.text = myManager.getDescription ();
	}
	
}

