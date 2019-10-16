using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float moveSpeed = 7f;
	public float moveDist = 0f;
	public GameObject bullet;
	public Transform thisTransform;
	public Vector3 movement;
	public Vector2 playerSize;
	public Vector2 playableSize;

	private float shootCooldown = 0.05f;
	private float shootCooldownDef = 0.05f;
	private Vector2 realPlayableSize;
	private Vector3 displacement;

	private void Awake() {
		thisTransform = transform;
		movement = Vector3.zero;
		playerSize = GetComponent<SpriteRenderer>().bounds.size;
		playableSize = Brain.main.areaRenderer.bounds.size;
		realPlayableSize = playableSize - playerSize;
		displacement = Vector3.zero;
	}

	private void Update() {
		movement = Vector3.zero;
		displacement = Vector3.zero;
		if (shootCooldown > 0f) {
			shootCooldown -= Time.deltaTime;
		}
		PlayerControl();
		thisTransform.localPosition += movement;
		PlayerCheckPos();
		PlayerShoot();
	}

	private void PlayerCheckPos() {
		if (thisTransform.localPosition.x < -realPlayableSize.x / 2) {
			displacement.x = -realPlayableSize.x / 2 - thisTransform.localPosition.x;
		} else if (thisTransform.localPosition.x > realPlayableSize.x / 2) {
			displacement.x = realPlayableSize.x / 2 - thisTransform.localPosition.x;
		}

		if (thisTransform.localPosition.y < -realPlayableSize.y / 2) {
			displacement.y = -realPlayableSize.y / 2 - thisTransform.localPosition.y;
		} else if (thisTransform.localPosition.y > realPlayableSize.y / 2) {
			displacement.y = realPlayableSize.y / 2 - thisTransform.localPosition.y;
		}
		thisTransform.localPosition += displacement;
	}

	private void PlayerControl() {
		moveDist = Time.deltaTime * moveSpeed;
		movement.x = moveDist * Input.GetAxisRaw("Horizontal");
		movement.y = moveDist * Input.GetAxisRaw("Vertical");
	}

	private void PlayerShoot() {
		if (Input.GetButton("Fire1") && shootCooldown <= 0f) {
			Instantiate(bullet, thisTransform.position, Quaternion.identity, Brain.main.area.transform);
			while (shootCooldown <= 0f) {
				shootCooldown += shootCooldownDef;
			}
		}
	}
}
