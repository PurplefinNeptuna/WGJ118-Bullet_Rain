using UnityEngine;

public class PlayerBullet : MonoBehaviour {
	public float speed = 25f;
	public LayerMask enemyLayer;
	private Transform thisTransform;
	private SpriteRenderer thisRenderer;
	private Collider2D[] colliderHitBuffer = new Collider2D[16];

	private void Awake() {
		thisTransform = transform;
		thisRenderer = GetComponent<SpriteRenderer>();
	}

	private void Update() {
		if (!thisRenderer.isVisible) {
			Destroy(gameObject);
		}
	}

	private void FixedUpdate() {
		thisTransform.localPosition += new Vector3(0f, speed * Time.fixedDeltaTime, 0f);
		int count = Physics2D.OverlapAreaNonAlloc((-1f / 2f) * thisRenderer.bounds.size + thisTransform.position, (1f / 2f) * thisRenderer.bounds.size + thisTransform.position, colliderHitBuffer, enemyLayer);
		for (int i = 0; i < count; i++) {
			colliderHitBuffer[i].GetComponent<Enemy>().health--;
		}
		if (count > 0) {
			Destroy(gameObject);
		}
	}
}
