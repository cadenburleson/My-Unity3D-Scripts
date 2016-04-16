using UnityEngine;
using System.Collections;

public class WormCreator : MonoBehaviour {
	void Example() {
		foreach (Transform child in transform) {
			child.position += Vector3.up * 100.0F * Time.deltaTime;
		}
	}
}
