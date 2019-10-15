using UnityEngine;

public class Enemy : MonoBehaviour {
	public int health = 100;
	private void Update() {
		if (health <= 0) {
			Destroy(gameObject);
		}
	}
}
