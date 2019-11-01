using UnityEngine;

public class BaseEnemy : MonoBehaviour {
	public int health = 100;
	public float speed = 3f;
	public Transform thisTransform;
	public Vector3 entrancePos;
	protected bool entranceDone;

	private void Awake() {
		thisTransform = transform;
		entranceDone = false;
		AIAwake();
	}

	private void Update() {
		if(health <= 0) {
			Destroy(gameObject);
		}
		if(!entranceDone) {
			EntranceMove(Time.deltaTime);
		}
		else {
			AIUpdate(Time.deltaTime);
		}
	}

	private void EntranceMove(float deltaTime) {
		float dist = Vector3.Distance(thisTransform.position, entrancePos);
		Vector3 between = entrancePos - thisTransform.position;
		if(!Mathf.Approximately(dist, 0f)) {
			Vector3 movement = between.normalized * deltaTime * speed;
			movement = Utility.MinVec3(movement, between);
			thisTransform.localPosition += movement;
		}
		else {
			entranceDone = true;
		}
	}

	public virtual void AIAwake() {
	}

	public virtual void AIUpdate(float deltaTime) {
	}
}
