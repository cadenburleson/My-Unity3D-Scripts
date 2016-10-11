using UnityEngine;
using UnityEngine.UI;

public class ManagerController : MonoBehaviour {

	ManagerData myManager;

	[SerializeField]
	string managerName;

	[SerializeField]
	int businessIdToLoad;

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
	Button hireButton;

	[SerializeField]
	Business businessToRun;

	FileService fileService;

//	 Use this for initialization
	void Start () {

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
			updateText ();	
			fileService.saveManager (myManager);
			Debug.Log (string.Format ("Manager init () " + "Manager Name: {0},  Manager Price: {1}, Manager Description: {2}", myManager.getName(), myManager.getPriceVal(), myManager.getDescription() ) );
		}else {
			Debug.Log ("Manager // your manager was NOT null");
			Debug.Log (string.Format ("Manager Name: {0},  Manager Price: {1}, Manager Description: {2}", myManager.getName(), myManager.getPriceVal(), myManager.getDescription()));
		}

		updateText ();
			
	}

	void updateText(){
		nameText.text = myManager.getName ();
		priceText.text = myManager.getPriceVal ().ToString ("c");
		descriptionText.text = myManager.getDescription ();
	}
	
}

