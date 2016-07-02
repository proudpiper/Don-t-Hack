using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectGenerator : MonoBehaviour {
	public float startOffset;
	public float releaseRate;

	public GameObject smogCloud, pollenCloud;

	List<GameObject> damageObjects = new List<GameObject> ();

	Timer spawnTimer;

	// Use this for initialization
	void Start () {
		damageObjects.Add (smogCloud);
		damageObjects.Add (pollenCloud);

		spawnTimer = new Timer ();

		if (startOffset <= 0) {
			Init ();
		}
		else {
			spawnTimer.StartTimer (startOffset, Init);
		}
	}

	void Init(){
		spawnTimer.StartTimer(releaseRate, SpawnObject);
	}

	void SpawnObject(){
		Instantiate(damageObjects[Random.Range(0,damageObjects.Count)], transform.position, transform.rotation);
		spawnTimer.ResetTimer ();
	}
}
