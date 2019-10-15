using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour {
	public static Brain main;

	public GameObject area;
	
	private void Awake() {
		if (main == null) {
			main = this;
		} else if (main != this) {
			Destroy(gameObject);
		}
	}

}
