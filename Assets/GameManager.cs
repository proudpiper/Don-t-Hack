using System;
using UnityEngine;

public class GameManager : MonoBehaviour {
	Player player;

	void Start(){
		player = GameObject.Find ("MainCharacterKid").GetComponent<Player> ();

		Medicine.SetupMedicineDereferencer (player);
	}
}