using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectGenerator : MonoBehaviour {
	public float startOffset;
	public float shortestRate;
	public float longestRate;

	protected Timer spawnTimer;

	// Use this for initialization
	void Start () {
		Setup ();
		spawnTimer = new Timer ();
		if (startOffset <= 0) {
			Init ();
		}
		else {
			spawnTimer.StartTimer (startOffset, Init);
		}
	}

	protected virtual void Setup(){}
	protected virtual void Init(){}
	protected virtual void SpawnObject(){}
}
