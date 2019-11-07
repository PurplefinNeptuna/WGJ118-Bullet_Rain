using UnityEngine;

public class Popcorn1 : BaseEnemy {
	private Vector3 targetDir;

	public override void AIAwake() {
		speed = 8f;
		entranceDone = true;
		health = 2;
	}

	private void Start() {
		targetDir = Brain.main.player.thisTransform.localPosition;
		targetDir -= thisTransform.localPosition;
		targetDir.Normalize();
		thisTransform.localRotation = Utility.TopDownRotationFromDirection(targetDir);
	}

	public override void AIUpdate(float deltaTime) {
		thisTransform.localPosition += targetDir * deltaTime * speed;
		if(thisTransform.localPosition.y < -7f) {
			Destroy(gameObject);
		}
	}
}
