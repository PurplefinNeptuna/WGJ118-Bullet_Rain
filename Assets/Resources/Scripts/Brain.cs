using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour {
	public static Brain main;

	public GameObject area;
	public SpriteRenderer areaRenderer;

	private void Awake() {
		if(main == null) {
			main = this;
		}
		else if(main != this) {
			Destroy(gameObject);
		}

		areaRenderer = area.GetComponent<SpriteRenderer>();
	}

	public bool PointInArea(Vector2 worldPoint) {
		return areaRenderer.bounds.Contains(worldPoint);
	}

}
