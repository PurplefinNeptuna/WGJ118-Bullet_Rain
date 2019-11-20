using UnityEngine;
using System.Collections;

public class Norm0 : BaseEnemy {
	private Vector3 targetDir = Vector3.down;

	public override void AIAwake() {
		speed = 3f;
		entranceDone = true;
		health = 5;
		thisTransform.localRotation = Utility.TopDownRotationFromDirection(targetDir);
	}

	public override void AIUpdate(float deltaTime) {
		thisTransform.localPosition += targetDir * deltaTime * speed;
		if(thisTransform.localPosition.y < -7f) {
			Destroy(gameObject);
		}
	}
}
