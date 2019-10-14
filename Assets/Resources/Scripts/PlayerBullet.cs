using UnityEngine;

public class PlayerBullet : MonoBehaviour {
	public float speed = 25f;
	private Transform thisTransform;
	private SpriteRenderer thisRenderer;

	private void Awake() {
		thisTransform = transform;
		thisRenderer = GetComponent<SpriteRenderer>();
	}

	private void Update() {
		if(!thisRenderer.isVisible){
			Destroy(gameObject);
		}
	}

	private void FixedUpdate() {
		thisTransform.localPosition += new Vector3(0f, speed * Time.fixedDeltaTime, 0f);
	}
}
