using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimalGenerator : ObjectGenerator {
	public GameObject horse;

	protected override void Init(){
		spawnTimer.StartTimer(Random.Range(shortestRate,longestRate), SpawnObject);
	}

	protected override void SpawnObject(){
		Instantiate(horse, transform.position, transform.rotation);
		spawnTimer.StartTimer (Random.Range(shortestRate,longestRate), SpawnObject);
	}
}