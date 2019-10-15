using UnityEngine;

public class BaseBullet {
	public GameObject bullet;
	public float defaultSpeed;
	public float speed;
	public Vector2 defaultDirection;
	public Vector2 direction;
	public GameObject source;
	public int damage;

	private Vector3 displacement;

	public void Update(float deltaTime) {
		PreUpdate(deltaTime);
		direction.Normalize();
		displacement = direction * (speed * deltaTime);
		bullet.transform.localPosition += displacement;
	}

	public virtual void PreUpdate(float deltaTime) {

	}
}
