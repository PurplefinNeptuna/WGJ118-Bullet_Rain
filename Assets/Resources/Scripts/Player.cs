using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float moveSpeed = 5f;
	public float moveDist = 0f;
	public GameObject area;
	public Transform thisTransform;
	public Vector3 movement;
	public Vector2 playerSize;
	public Vector2 playableSize;

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
	}

	private void PlayerControl() {
		moveDist = Time.deltaTime * moveSpeed;
		movement.x = moveDist * Input.GetAxisRaw("Horizontal");
		movement.y = moveDist * Input.GetAxisRaw("Vertical");
	}
}