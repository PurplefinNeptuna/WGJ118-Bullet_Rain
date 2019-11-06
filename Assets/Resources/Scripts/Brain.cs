using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour {
	public static Brain main;

	public GameObject area;
	public SpriteRenderer areaRenderer;
	public Player player;
	public List<TextAsset> levels;
	public int lvlID;
	public float levelProgress = 0f;
	public float levelSpeed = 10f;
	public bool levelDone = false;

	private void Awake() {
		if(main == null) {
			main = this;
		}
		else if(main != this) {
			Destroy(gameObject);
		}

		areaRenderer = area.GetComponent<SpriteRenderer>();
		levels = new List<TextAsset>(Resources.LoadAll<TextAsset>("Levels"));
		lvlID = 0;
	}

	private void Update() {
		if(!levelDone) {
			levelProgress += Time.deltaTime * levelSpeed;
		}
		else {
			levelDone = false;
			levelProgress = 0f;
			lvlID++;
		}
	}

	public bool PointInArea(Vector2 worldPoint) {
		return areaRenderer.bounds.Contains(worldPoint);
	}

}
