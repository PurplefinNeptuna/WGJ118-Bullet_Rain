using UnityEngine;

public class BaseEnemy : MonoBehaviour {
	public int health = 100;
	public Transform thisTransform;

	private void Awake() {
		thisTransform = transform;
		AIAwake();
	}

	private void Update() {
		if (health <= 0) {
			Destroy(gameObject);
		}
		AIUpdate(Time.deltaTime);
	}

	public virtual void AIAwake(){
	}

	public virtual void AIUpdate(float deltaTime){
	}
}
