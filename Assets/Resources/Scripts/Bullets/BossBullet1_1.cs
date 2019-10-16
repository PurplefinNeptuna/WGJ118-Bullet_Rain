using System;
using UnityEngine;

public class BossBullet1_1 : BaseBullet {
	private float totalTime = 0f;
	public override void PreUpdate(float deltaTime) {
		totalTime += deltaTime;
		speed = defaultSpeed * (float)(Math.Tanh(Math.Max(2f - totalTime, -2f)));
	}

	public override void PostUpdate(float deltaTime) {
		if (Vector3.Distance(transform.localPosition, source) >= 9f) {
			BulletManager.main.Destroy(this);
		}
	}
}
