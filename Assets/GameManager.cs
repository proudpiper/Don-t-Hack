using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	Player player;
	Timer timer;

	void Start(){
		player = GameObject.Find ("MainCharacterKid").GetComponent<Player> ();
		Medicine.SetupMedicineDereferencer (player);
		timer = new Timer (10.0f, winGameTimer);
		timer.StartTimer(60.0f, winGameTimer);
	}

	void winGameTimer() {
		timer.StopTimer ();
		SceneManager.LoadScene ("EndScene");
	}
}