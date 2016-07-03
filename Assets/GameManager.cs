using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	Player player;
	Timer timer;

	public ObjectSpawner smogSpawnerTop, smogSpawnerBottom,
		pollenSpawnerTop, pollerSpawnerBottom,
		no_fur_cat_spawner,
		fur_cat_spawner,
		dog_spawner,
		horse_spawner;

	void Start(){
		player = GameObject.Find ("MainCharacterKid").GetComponent<Player> ();
		Medicine.SetupMedicineDereferencer (player);
		//timer = new Timer (10.0f, winGameTimer);
		//timer.StartTimer(60.0f, winGameTimer);
		List<Timer> segmentTimers = new List<Timer>();

		segmentTimers.Add(new Timer (4, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (7, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (8, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (10, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (12, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (13, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (14, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (15, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (18, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer(19, smogSpawnerTop.SpawnObject));

		segmentTimers.Add(new Timer (21, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer(21.75f, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (22.5f, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer(23.25f, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (24f, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer(24.75f, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (25.5f, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer(26.5f, smogSpawnerTop.SpawnObject));
		//segmentTimers.Add(new Timer (27.5f, smogSpawnerBottom.SpawnObject));
		//segmentTimers.Add(new Timer(28.5f, smogSpawnerTop.SpawnObject));

		for (int i = 0; i < segmentTimers.Count; i++)
			segmentTimers [i].ResetTimer ();
	}

	void winGameTimer() {
		//timer.StopTimer ();
		SceneManager.LoadScene ("EndScene");
	}
}