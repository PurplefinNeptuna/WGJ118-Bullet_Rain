using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {

	public static BulletManager main;

	public List<BaseBullet> bullets;

	private void Awake() {
		#region singleton
		if (main == null) {
			main = this;
		} else if (main != this) {
			Destroy(gameObject);
		}
		#endregion

		bullets = new List<BaseBullet>();
	}

	private void FixedUpdate() {
		float deltaTime = Time.fixedDeltaTime;
		for(int i=0; i<bullets.Count; i++){
			bullets[i].Update(deltaTime);
		}
	}

	/// <summary>
	/// Spawn new projectile
	/// </summary>
	/// <param name="worldPos">position in 2D space</param>
	/// <param name="speed">speed</param>
	/// <param name="direction">direction</param>
	/// <param name="source">source of projectile</param>
	/// <param name="damage">damage</param>
	/// <param name="shapeName">name of the projectile prefab</param>
	/// <param name="behaviourName">name of the projectile AI class</param>
	/// <param name="sound">projectile sound when spawning</param>
	/// <returns>GameObject of spawned projectile</returns>
	public BaseBullet Spawn(Vector2 worldPos, float speed, Vector2 direction, GameObject source, int damage = 5, string shapeName = "Bullet", string behaviourName = "BaseBullet", string sound = null) {
		Type type;
		GameObject prefab = Resources.Load<GameObject>("Prefabs/Bullets/" + shapeName);
		try {
			type = Type.GetType(behaviourName);
		} catch {
			//type = typeof(DefaultBullet);
			return null;
		}

		direction.Normalize();
		GameObject result = Instantiate(prefab, worldPos, Quaternion.identity, Brain.main.area.transform);
		BaseBullet bulletSpawned = Activator.CreateInstance(type)as BaseBullet;
		bulletSpawned.bullet = result;
		bulletSpawned.source = source;
		bulletSpawned.defaultSpeed = speed;
		bulletSpawned.speed = speed;
		bulletSpawned.defaultDirection = direction;
		bulletSpawned.direction = direction;
		bulletSpawned.damage = damage;
		bulletSpawned.BaseInit();
		//result.AddComponent(type);
		//result.transform.rotation = MVUtility.TopDownRotationFromDirection(direction);
		//BaseBullet projectile = result.GetComponent(type) as BaseBullet;
		bullets.Add(bulletSpawned);
		return bulletSpawned;
	}

	/// <summary>
	/// Destroy the bullet
	/// </summary>
	/// <param name="theBullet">the bullet to be deleted</param>
	public void Destroy(BaseBullet theBullet){
		Destroy(theBullet.bullet);
		bullets.Remove(theBullet);
	}
}
