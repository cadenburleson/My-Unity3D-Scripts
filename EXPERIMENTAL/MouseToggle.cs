using UnityEngine;
using System.Collections;

public class MouseToggle : MonoBehaviour {

//	private bool onOff = false;

	private bool cursorShouldBeLocked = false;


	// Used for references between scripts gets called even if script is not active.
	void Awake () {
		Cursor.lockState = CursorLockMode.Locked;
		Debug.Log ("-Awake-"+"Cursor LockState = " + Cursor.lockState);
	}

	// Use this for initialization
	void Start () {
		Debug.Log (" -Start- " + "Cursor LockState = " + Cursor.lockState);

	}
	
	// Update is called once per frame
	void Update () {

		if (cursorShouldBeLocked)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		else
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
			

		if (Input.GetKeyDown(KeyCode.E)) {
			cursorShouldBeLocked = !cursorShouldBeLocked;


//			onOff = !onOff; // toggles onOff at each click

//			if (onOff) {
//				Cursor.visible = onOff;
//				print ("left");
//				Debug.Log ("Cursor LockState = " + Cursor.lockState);
//			} else {
//				Cursor.visible = onOff;
//				Debug.Log ("Cursor LockState = " + Cursor.lockState);
//			}


		}
	
	}
}
