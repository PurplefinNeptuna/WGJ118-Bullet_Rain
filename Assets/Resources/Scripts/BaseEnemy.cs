using UnityEngine;

public class BaseEnemy : MonoBehaviour {
	public int health = 100;
	public float speed = 3f;
	public Transform thisTransform;
	public Vector3 entrancePos;
	protected bool entranceDone;
	public bool stat;

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
		Vector3 between = entrancePos - thisTransform.position;
		stat = entrancePos.Similiar(thisTransform.position);
		if(!stat) {
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

	private void OnDestroy() {
		SpawnManager.DestroyEnemy(this);
	}
}
