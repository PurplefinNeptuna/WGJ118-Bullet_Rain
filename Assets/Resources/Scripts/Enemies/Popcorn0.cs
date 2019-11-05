using UnityEngine;

public class Popcorn0: BaseEnemy{
	private Vector3 targetDir;

	public override void AIAwake(){
		speed = 10f;
		entranceDone = true;
	}

	private void Start() {
		targetDir = Brain.main.player.thisTransform.localPosition;
		targetDir += new Vector3(0f, 2f, 0f);
		targetDir -= thisTransform.localPosition;
		targetDir.Normalize();		
	}

	public override void AIUpdate(float deltaTime){
		thisTransform.localPosition += targetDir * deltaTime * speed;
	}
}