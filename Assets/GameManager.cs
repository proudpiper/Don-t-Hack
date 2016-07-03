using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	Player player;
	Timer timer;

	public ObjectSpawner smogSpawnerTop, smogSpawnerBottom,
		pollenSpawnerTop, pollenSpawnerBottom,
		no_fur_cat_spawner,
		fur_cat_spawner,
		dog_spawner,
		horse_spawner;

	void winGameTimer() {
		//timer.StopTimer ();
		SceneManager.LoadScene ("EndScene");
	}

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
		segmentTimers.Add(new Timer (14, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (15, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (18, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer(19, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (21, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer(23, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (25, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer(27f, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (29, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer(31, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (33, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer(35, Segment2));

		for (int i = 0; i < segmentTimers.Count; i++)
			segmentTimers [i].ResetTimer ();
	}

	void Segment2(){
		List<Timer> segmentTimers = new List<Timer> ();

		pollenSpawnerBottom.SpawnObject ();
		segmentTimers.Add(new Timer (2, pollenSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (3, pollenSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (4, pollenSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (6, pollenSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (8, pollenSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (8.10f, pollenSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (9, pollenSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (9.10f, pollenSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (12, Segment3));

		for (int i = 0; i < segmentTimers.Count; i++)
			segmentTimers [i].ResetTimer ();
	}

	void Segment3(){
		List<Timer> segmentTimers = new List<Timer> ();

		segmentTimers.Add(new Timer (1, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (1, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (1.10f, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (1.10f, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (1.25f, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (1.25f, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (1.35f, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (1.35f, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (1.5f, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (1.5f, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (1.65f, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (1.65f, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (1.75f, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (1.75f, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (1.85f, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (1.85f, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (2, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (2, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (5, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (5, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (5.10f, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (5.10f, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (5.25f, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (5.25f, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (5.35f, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (5.35f, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (5.5f, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (5.5f, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (5.65f, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (5.65f, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (5.75f, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (5.75f, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (5.85f, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (5.85f, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (6, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (6, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer(7, Segment4));

		for (int i = 0; i < segmentTimers.Count; i++)
			segmentTimers [i].ResetTimer ();
	}

	void Segment4(){
		List<Timer> segmentTimers = new List<Timer> ();

		segmentTimers.Add(new Timer (3.2f, no_fur_cat_spawner.SpawnObject));
		segmentTimers.Add(new Timer (5.5f, no_fur_cat_spawner.SpawnObject));
		segmentTimers.Add(new Timer (8, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (8, no_fur_cat_spawner.SpawnObject));
		segmentTimers.Add(new Timer (11, fur_cat_spawner.SpawnObject));
		segmentTimers.Add(new Timer (11.5f, pollenSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (14, no_fur_cat_spawner.SpawnObject));
		segmentTimers.Add(new Timer (14.5f, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (15, fur_cat_spawner.SpawnObject));
		segmentTimers.Add(new Timer (16, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (17, fur_cat_spawner.SpawnObject));
		segmentTimers.Add(new Timer (19, pollenSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (19.1f, pollenSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (19.2f, pollenSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (19.3f, pollenSpawnerTop.SpawnObject));
		segmentTimers.Add (new Timer (22, no_fur_cat_spawner.SpawnObject));
		segmentTimers.Add(new Timer (22, pollenSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (22.1f, pollenSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (22.2f, pollenSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (22.3f, pollenSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (23, fur_cat_spawner.SpawnObject));
		segmentTimers.Add(new Timer (25, no_fur_cat_spawner.SpawnObject));
		segmentTimers.Add(new Timer (26, Segment5));

		for (int i = 0; i < segmentTimers.Count; i++)
			segmentTimers [i].ResetTimer ();
	}

	void Segment5(){
		List<Timer> segmentTimers = new List<Timer> ();

		segmentTimers.Add(new Timer (3, dog_spawner.SpawnObject));
		segmentTimers.Add(new Timer (4, no_fur_cat_spawner.SpawnObject));
		segmentTimers.Add(new Timer (4.5f, no_fur_cat_spawner.SpawnObject));
		segmentTimers.Add(new Timer (5, no_fur_cat_spawner.SpawnObject));
		segmentTimers.Add(new Timer (6, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (6.1f, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (6.2f, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (6.3f, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (6.6f, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (6.7f, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (6.8f, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (7, dog_spawner.SpawnObject));
		segmentTimers.Add(new Timer (7.5f, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (8.5f, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (9.5f, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (10.5f, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (11.5f, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (11.5f, no_fur_cat_spawner.SpawnObject));
		segmentTimers.Add(new Timer (12.5f, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (13.5f, Segment6));

		for (int i = 0; i < segmentTimers.Count; i++)
			segmentTimers [i].ResetTimer ();
	}

	void Segment6(){
		List<Timer> segmentTimers = new List<Timer> ();

		segmentTimers.Add (new Timer (1, fur_cat_spawner.SpawnObject));
		segmentTimers.Add (new Timer (1, dog_spawner.SpawnObject));

		segmentTimers.Add(new Timer(3, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (5, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add(new Timer (5, no_fur_cat_spawner.SpawnObject));
		segmentTimers.Add(new Timer(7, smogSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (9, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add (new Timer (9, fur_cat_spawner.SpawnObject));
		segmentTimers.Add(new Timer(11, smogSpawnerTop.SpawnObject));
		segmentTimers.Add (new Timer (12, dog_spawner.SpawnObject));
		segmentTimers.Add(new Timer (13, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add (new Timer (17, horse_spawner.SpawnObject));
		segmentTimers.Add (new Timer (19, Segment7));

		for (int i = 0; i < segmentTimers.Count; i++)
			segmentTimers [i].ResetTimer ();
	}

	void Segment7(){
		List<Timer> segmentTimers = new List<Timer> ();

		segmentTimers.Add (new Timer (1, fur_cat_spawner.SpawnObject));
		segmentTimers.Add (new Timer (1.5f, no_fur_cat_spawner.SpawnObject));
		segmentTimers.Add (new Timer (1.9f, no_fur_cat_spawner.SpawnObject));
		segmentTimers.Add (new Timer (1.7f, dog_spawner.SpawnObject));

		segmentTimers.Add (new Timer (2, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add (new Timer (2.5f, pollenSpawnerTop.SpawnObject));
		segmentTimers.Add (new Timer (2.8f, smogSpawnerBottom.SpawnObject));
		segmentTimers.Add (new Timer (3, fur_cat_spawner.SpawnObject)); 
		segmentTimers.Add (new Timer (3.6f, smogSpawnerBottom.SpawnObject));

		segmentTimers.Add (new Timer (3.8f, horse_spawner.SpawnObject));
		segmentTimers.Add(new Timer (4.8f, no_fur_cat_spawner.SpawnObject));
		segmentTimers.Add(new Timer (5.13f, no_fur_cat_spawner.SpawnObject));
		segmentTimers.Add(new Timer (5.63f, no_fur_cat_spawner.SpawnObject));
		segmentTimers.Add(new Timer (6.1f, pollenSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (6.2f, pollenSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (6.3f, pollenSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (7, pollenSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (7.1f, pollenSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (7.1f, no_fur_cat_spawner.SpawnObject));
		segmentTimers.Add(new Timer (7.2f, pollenSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (7.3f, pollenSpawnerTop.SpawnObject));
		segmentTimers.Add(new Timer (7.3f, no_fur_cat_spawner.SpawnObject));
		segmentTimers.Add (new Timer (8, winGameTimer));

		for (int i = 0; i < segmentTimers.Count; i++)
			segmentTimers [i].ResetTimer ();
	}
}