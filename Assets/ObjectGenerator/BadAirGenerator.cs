using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BadAirGenerator : ObjectGenerator {
	public GameObject smogCloud, pollenCloud;

	List<GameObject> damageObjects = new List<GameObject> ();

	protected override void Setup(){
		damageObjects.Add (smogCloud);
		damageObjects.Add (pollenCloud);
	}

	protected override void Init(){
		spawnTimer.StartTimer(Random.Range(shortestRate,longestRate), SpawnObject);
	}

	protected override void SpawnObject(){
		Instantiate(damageObjects[Random.Range(0,damageObjects.Count)], transform.position, transform.rotation);
		spawnTimer.StartTimer (Random.Range(shortestRate,longestRate), SpawnObject);
	}
}
