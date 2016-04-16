using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	// The Text object to use to display timer text on the screen.
	public Text timer_text;	
	public float timerAmount = 10.0f;

	// 0 : timer is stopped.
	// 1 = increase timer.
	// -1 decrease timer.
	private int time_Direction;

	void Awake () {
		
		if (timer_text == null) {
			Debug.LogAssertion ("please assign a text to this timer to have your time displayed");
		}
	}

// Update is called once per frame
	void Update () {
			
			// Leave this out of any loops / functions
			
			
		if (timerAmount >= 0) {
			timerAmount -= Time.deltaTime;	
		}

//		while (timerAmount >= 0 ) {
//			timerAmount -= Time.deltaTime;	
//		}
//
			timer_text.text = timerAmount.ToString("00:00:00");
	
		
//		if (time_Direction == 0 ) {
//			timerAmount = 0;
//		}
//		if (time_Direction == 1) {
//			timerAmount += Time.deltaTime;
//		}
//		if (time_Direction == -1) {
//			timerAmount -= Time.deltaTime;
//		}


	}
		

}
