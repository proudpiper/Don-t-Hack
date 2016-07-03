using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DDR_Controller : MonoBehaviour{
	const int MaxCommandStrLength = 5;

	void Start(){
		for (int i = 0; i < MaxCommandStrLength; i++) {
			commandStr [i] = KeyCode.JoystickButton9;
		}
		timer = new Timer (1.5f, CheckCommand);
		this.player = transform.parent.GetComponent<Player> ();
	}

	Player player;
	Timer timer;

	//string commandStr;
	KeyCode[] commandStr = new KeyCode[MaxCommandStrLength];
	int commandStrIndex = 0;

	public void AddCommandChar(KeyCode commandChar){
		if (commandStrIndex < MaxCommandStrLength) {
			commandStr [commandStrIndex] = commandChar;
			++commandStrIndex;
		}
		if (commandStrIndex == MaxCommandStrLength) {
			CheckCommand ();
		}
	}

	void CheckCommand(){
		timer.StopTimer ();
		string medicineName;
		if (Medicine.patternDerefernecer.TryGetValue (commandStr, out medicineName)) {
			player.UseMedicine (medicineName);
		}
		else {
			InvalidMedicineCommand ();
		}
			
		for (int i = 0; i < MaxCommandStrLength; i++) {
			commandStr [i] = KeyCode.JoystickButton9;
		}
		commandStrIndex = 0;
	}

	public void ReadyListen(){
		timer.ResetTimer ();
	}

	void InvalidMedicineCommand(){
		Debug.Log ("InvalidMedicine!");
	}
}
