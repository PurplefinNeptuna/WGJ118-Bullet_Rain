using UnityEngine;

public class BaseBullet {

	public Vector3? Position {
		get {
			return transform?.localPosition;
		}
	}

	public GameObject bullet;
	public Transform transform;
	public float defaultSpeed;
	public float speed;
	public Vector2 defaultDirection;
	public Vector2 direction;
	public GameObject source;
	public int damage;

	private Vector3 displacement;
	private SpriteRenderer renderer;

	public void BaseInit() {
		renderer = bullet.GetComponent<SpriteRenderer>();
		transform = bullet.transform;
		Init();
	}

	public virtual void Init() {

	}

	public void Update(float deltaTime) {
		PreUpdate(deltaTime);
		direction.Normalize();
		displacement = direction * (speed * deltaTime);
		bullet.transform.localPosition += displacement;
		PostUpdate(deltaTime);
	}

	public virtual void PreUpdate(float deltaTime) {

	}

	public virtual void PostUpdate(float deltaTime) {
		if (!Brain.main.PointInArea((Vector2)Position)) {
			BulletManager.main.Destroy(this);
		}
	}
}
