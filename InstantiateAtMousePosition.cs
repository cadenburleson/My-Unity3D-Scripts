using UnityEngine;
using System.Collections;

public class InstantiateAtMousePosition : MonoBehaviour {

	Vector3 mousePosition,targetPosition;

	//To Instantiate TargetObject at mouse position
	public Transform targetObject;

	float distance=10f;

	// Update is called once per frame
	void Update () {

		//To get the current mouse position
		mousePosition = Input.mousePosition;

		//Convert the mousePosition according to World position
		targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x,mousePosition.y,distance));

		//Set the position of targetObject
		targetObject.position=targetPosition;

		//If Left Button is clicked
		if(Input.GetMouseButtonUp(0))
		{
			//create the instance of targetObject and place it at given position.
			Instantiate(targetObject,targetObject.transform.position,targetObject.transform.rotation);    
		}
	}
}