using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuTogglable : MonoBehaviour {

	/// <summary>
	/// Attach this to the menu(UI Element) you want to toggle
	/// and attach the Toggle Function to the button you want
	/// to display your Menu!
	/// </summary>

	public bool toggleBool = false;

	public void Toggle() {
		toggleBool = !toggleBool;
		this.gameObject.SetActive (toggleBool);
	}


}
