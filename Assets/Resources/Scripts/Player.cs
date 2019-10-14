using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float moveSpeed = 5f;
	public float moveDist = 0f;
	public GameObject area;
	public GameObject bullet;
	public Transform thisTransform;
	public Vector3 movement;
	public Vector2 playerSize;
	public Vector2 playableSize;

	private float shootCooldown = 0.05f;
	private float shootCooldownDef = 0.05f;

	private void Awake() {
		thisTransform = transform;
		movement = Vector3.zero;
		playerSize = GetComponent<SpriteRenderer>().bounds.size;
		playableSize = area.GetComponent<SpriteRenderer>().bounds.size;
	}

	private void Start() {
		Debug.Log(playerSize);
		Debug.Log(playableSize);
	}

	private void Update() {
		movement = Vector3.zero;
		PlayerControl();
		thisTransform.localPosition += movement;
		shootCooldown -= Time.deltaTime;
		PlayerShoot();
		if(shootCooldown<=0f){
			shootCooldown += shootCooldownDef;
		}
	}

	private void PlayerControl() {
		moveDist = Time.deltaTime * moveSpeed;
		movement.x = moveDist * Input.GetAxisRaw("Horizontal");
		movement.y = moveDist * Input.GetAxisRaw("Vertical");
	}

	private void PlayerShoot() {
		if (Input.GetButton("Fire1") && shootCooldown <= 0f) {
			Instantiate(bullet, thisTransform.position, Quaternion.identity, area.transform);
		}
	}
}
