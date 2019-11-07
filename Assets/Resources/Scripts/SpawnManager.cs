using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public struct EnemyData {
	public float dist;
	public string enemyType;
	public Vector3 spawnPos;
	public Vector3 targetEntrance;

	public EnemyData(float dist, string enemyType, Vector3 spawnPos, Vector3 targetEntrance) {
		this.dist = dist;
		this.enemyType = enemyType;
		this.spawnPos = spawnPos;
		this.targetEntrance = targetEntrance;
	}

	public EnemyData(string data) {
		List<string> args = new List<string>(data.Split());
		float.TryParse(args[0], out dist);
		enemyType = args[1];
		float.TryParse(args[2], out float s1);
		float.TryParse(args[3], out float s2);
		float.TryParse(args[4], out float e1);
		float.TryParse(args[5], out float e2);
		spawnPos = new Vector3(s1, s2, 0f);
		targetEntrance = new Vector3(e1, e2, 0f);
	}
}

public class SpawnManager : MonoBehaviour {
	public static SpawnManager main;
	private TextAsset thisLevel;
	private int loadedLevel = -1;
	private Queue<EnemyData> enemyQueue;
	private int queueSize = 0;
	public EnemyData waitingEnemy;
	public List<BaseEnemy> activeEnemies;

	private void Awake() {
		#region singleton
		if(main == null) {
			main = this;
		}
		else if(main != this) {
			Destroy(gameObject);
		}
		#endregion

		enemyQueue = new Queue<EnemyData>();
		activeEnemies = new List<BaseEnemy>();
	}

	private void Update() {
		if(loadedLevel != Brain.main.lvlID) {
			LoadLevel(Brain.main.lvlID);
		}
		queueSize = enemyQueue.Count;

		while(waitingEnemy.dist <= Brain.main.levelProgress && enemyQueue.Count > 0) {
			SpawnEnemy(waitingEnemy);
			enemyQueue.Dequeue();
			if(enemyQueue.Count > 0) {
				waitingEnemy = enemyQueue.Peek();
			}
		}

		if(enemyQueue.Count == 0 && activeEnemies.Count == 0) {
			Brain.main.levelDone = true;
		}
	}

	public static void SpawnEnemy(EnemyData data) {
		Type type;
		GameObject prefab = Resources.Load<GameObject>("Prefabs/Enemies/" + data.enemyType);
		try {
			type = Type.GetType(data.enemyType);
		}
		catch {
			return;
		}

		GameObject result = Instantiate(prefab, data.spawnPos, Quaternion.identity, Brain.main.area.transform);
		BaseEnemy enemy = result.AddComponent(type) as BaseEnemy;
		enemy.entrancePos = data.targetEntrance;
		main.activeEnemies.Add(enemy);
	}

	public static void SpawnEnemy(string enemyPrefabName, string enemyBehaviourName, Vector3 spawnPos, Vector3 entrancePos) {
		Type type;
		GameObject prefab = Resources.Load<GameObject>("Prefabs/Enemies/" + enemyPrefabName);
		try {
			type = Type.GetType(enemyBehaviourName);
		}
		catch {
			return;
		}

		GameObject result = Instantiate(prefab, spawnPos, Quaternion.identity, Brain.main.area.transform);
		BaseEnemy enemy = result.AddComponent(type) as BaseEnemy;
		enemy.entrancePos = entrancePos;
		main.activeEnemies.Add(enemy);
	}

	public static void DestroyEnemy(BaseEnemy theEnemy) {
		main.activeEnemies.Remove(theEnemy);
	}

	private void LoadLevel(int lvlID) {
		thisLevel = Brain.main.levels[lvlID];
		loadedLevel = lvlID;

		List<string> enemyList = new List<string>(thisLevel.text.Split(new string[] { "\r\n", "\n" }, System.StringSplitOptions.RemoveEmptyEntries));
		foreach(string item in enemyList) {
			enemyQueue.Enqueue(new EnemyData(item));
		}

		waitingEnemy = enemyQueue.Peek();
	}
}
