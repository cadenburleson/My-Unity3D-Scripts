using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hover : MonoBehaviour {

	public int maxHoverHeight;
	public int hoverSpeed;

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * hoverSpeed, maxHoverHeight), transform.position.z);
	}//End of Update() function//



		


}
