using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Debugging : MonoBehaviour {
	
	[SerializeField]
	private GameObject debugPanel;
	public Text d_moneyText;
	public bool isDebugMenuActive;
	// Use this for initialization
	void Start () {
//		debugPanel.SetActive (true);
		IAnimal myAnimal1 = new Bear();
		IAnimal myAnimal2 = new Bat ();
		MakeAnimalSleep (myAnimal1);
		MakeAnimalSleep (myAnimal2);
	}
		
	// Update is called once per frame
	void Update () {
//		toggleBool = !toggleBool;
//		this.gameObject.SetActive (toggleBool);
		if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.D)) {
			Debug.Log ("You have pressed the debugger");
			isDebugMenuActive = !isDebugMenuActive;
			debugPanel.SetActive (isDebugMenuActive);
		}

	}

	void MakeAnimalSleep (IAnimal myAnimal) {
		myAnimal.Sleep ();
	}

}
