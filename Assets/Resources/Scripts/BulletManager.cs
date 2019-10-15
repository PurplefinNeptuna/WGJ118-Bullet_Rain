using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {

		public static BulletManager main;
		private void Awake() {
			if (main == null) {
				main = this;
			}
			else if (main != this) {
				Destroy(gameObject);
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
		public GameObject Spawn(Vector2 worldPos, float speed, Vector2 direction, GameObject source, int damage = 5, string shapeName = "Bullet", string behaviourName = "DefaultBullet", string sound = null) {
			Type type;
			GameObject prefab = Resources.Load<GameObject>("Bullets/" + shapeName);
			try {
				type = Type.GetType(behaviourName);
			}
			catch {
				//type = typeof(DefaultBullet);
				return null;
			}

			direction.Normalize();
			GameObject result = GameObject.Instantiate<GameObject>(prefab, worldPos, Quaternion.identity, Brain.main.area.transform);
			result.AddComponent(type);
			//result.transform.rotation = MVUtility.TopDownRotationFromDirection(direction);
			//BaseBullet projectile = result.GetComponent(type) as BaseBullet;
			//projectile.Source = source;
			//projectile.Friendly = friendly;
			//projectile.defaultSpeed = speed;
			//projectile.defaultDirection = direction;
			//projectile.Speed = speed;
			//projectile.Direction = direction;
			//projectile.damage = damage;
			return result;
		}
}
