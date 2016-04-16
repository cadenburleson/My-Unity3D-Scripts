using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

	[SerializeField]
	private string managerName;
	[SerializeField]
	private float managerPrice = 0f;

	public string managerDescription;



	[SerializeField]
	private Text nameText;
	[SerializeField]
	private Text priceText;


	public Text descriptionText;

	public Business businessToRun;

	// Use this for initialization
	void Start () {

//		managerName = managerName;
		nameText.text = managerName;
//
//		managerPrice = managerPrice;
		priceText.text = managerPrice.ToString("C0");

		// Make the businessToRun.(a function (getYourBusinessName))
//		managerDescription =  managerName + " will run the " + businessToRun.getName() + " business for:";
		descriptionText.text = managerDescription.ToString();


	}
	
	// Update is called once per frame
	void Update () {
	
	}




}
