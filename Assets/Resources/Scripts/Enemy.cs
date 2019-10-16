using UnityEngine;

public class Enemy : MonoBehaviour {
	public int health = 100;

	private void Start() {
		BulletManager.main.Spawn(transform.position, 8f, Vector2.down, gameObject);
	}

	private void Update() {
		if (health <= 0) {
			Destroy(gameObject);
		}
	}
}
