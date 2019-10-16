using UnityEngine;

public class Enemy : MonoBehaviour {
	public int health = 100;

	private void Update() {
		if (health <= 0) {
			Destroy(gameObject);
		}
	}

	private float shootCooldown = 0.02f;
	private float shootCooldownDef = 0.02f;
	private Vector2 shootDir;
	[Range(0f, 720f)]
	public float rotateSpeed = 360f;
	private void Awake() {
		shootDir = Vector2.down;
	}
	private void FixedUpdate() {
		shootDir = shootDir.RotateCW(rotateSpeed * Time.fixedDeltaTime);
		shootDir.Normalize();
		if (shootCooldown > 0f) {
			shootCooldown -= Time.deltaTime;
		} else {
			BulletManager.main.Spawn(transform.position, 6f, shootDir, gameObject, 5, "Bullet", "BossBullet1_1");
			shootCooldown += shootCooldownDef;
		}
	}
}
