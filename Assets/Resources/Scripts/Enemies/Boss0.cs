using UnityEngine;

public class Boss0 : BaseEnemy {
	private float shootCooldown = 0.02f;
	private float shootCooldownDef = 0.02f;
	private Vector2 shootDir;
	private Vector2 shootDir2;
	private Vector2 shootDir3;

	[Range(0f, 720f)]
	public float rotateSpeed = Mathf.PI * 100f;

	public override void AIAwake() {
		shootDir = Vector2.up;
		health = 1000;
	}

	public override void AIUpdate(float deltaTime) {
		thisTransform.localRotation = Utility.TopDownRotationFromDirection(shootDir);
		shootDir = shootDir.RotateCW(rotateSpeed * Time.fixedDeltaTime);
		shootDir.Normalize();
		shootDir2 = shootDir.RotateCW(120f);
		shootDir2.Normalize();
		shootDir3 = shootDir.RotateCCW(120f);
		shootDir3.Normalize();
		if(shootCooldown > 0f) {
			shootCooldown -= Time.deltaTime;
		}
		else {
			BulletManager.Spawn(transform.position, 3f, shootDir, gameObject, 5, "Bullet", "BossBullet1_1");
			BulletManager.Spawn(transform.position, 3f, shootDir2, gameObject, 5, "Bullet", "BossBullet1_1");
			BulletManager.Spawn(transform.position, 3f, shootDir3, gameObject, 5, "Bullet", "BossBullet1_1");
			shootCooldown += shootCooldownDef;
		}
	}
}
