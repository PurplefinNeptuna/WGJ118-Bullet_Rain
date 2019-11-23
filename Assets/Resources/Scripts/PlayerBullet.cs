using UnityEngine;

public class PlayerBullet : MonoBehaviour {
	public float speed = 25f;
	public LayerMask enemyLayer;
	private Transform thisTransform;
	private SpriteRenderer thisRenderer;
	private Collider2D[] colliderHitBuffer = new Collider2D[16];
	private Vector3 size;

	private void Awake() {
		thisTransform = transform;
		thisRenderer = GetComponent<SpriteRenderer>();
		size = thisRenderer.bounds.size;
		size.x *= 5;
	}

	private void Update() {
		if(!Brain.main.PointInArea(thisTransform.position)) {
			Destroy(gameObject);
		}
	}

	private void FixedUpdate() {
		thisTransform.localPosition += new Vector3(0f, speed * Time.fixedDeltaTime, 0f);
		int count = Physics2D.OverlapAreaNonAlloc((-1f / 2f) * size + thisTransform.position, (1f / 2f) * size + thisTransform.position, colliderHitBuffer, enemyLayer);
		for(int i = 0; i < count; i++) {
			colliderHitBuffer[i].GetComponent<BaseEnemy>().health--;
			//Debug.Log("Hit");
		}
		if(count > 0) {
			Destroy(gameObject);
		}
	}
}
