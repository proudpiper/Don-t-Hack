using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DDR_Controller : MonoBehaviour{
	const int MaxCommandStrLength = 5;

	void Start(){
		commandStr = "00000";
	}

	public DDR_Controller(Player player){
		this.player = player;
		timer.SetupTimer (3, CheckCommand);
	}
	public void Setup(Player player){
		this.player = player;
		timer = transform.FindChild ("DDR_Controller_Timer").GetComponent<Timer> ();
		timer.SetupTimer (3, CheckCommand);
	}

	Player player;
	Timer timer;

	string commandStr;
	int commandStrIndex = 0;

	public void AddCommandChar(char commandChar){
		if (commandStrIndex < MaxCommandStrLength) {
			switch (commandChar){
			case 'W': 
			case 'A':
			case 'S':
			case 'D':
				Debug.Log (commandStr);
				char[] commandStringArr = commandStr.ToCharArray ();
				commandStringArr [commandStrIndex] = commandChar;
				commandStr = new string(commandStringArr);
				++commandStrIndex;
				break;
			}

			if (commandStrIndex == MaxCommandStrLength) {
				CheckCommand ();
			}
		}
	}

	void CheckCommand(){
		timer.StopTimer ();
		string medicineName;
		Debug.Log (commandStr);
		if (Medicine.patternDerefernecer.TryGetValue (commandStr, out medicineName)) {
			player.UseMedicine (medicineName);
		}
		else {
			InvalidMedicineCommand ();
		}
			
		char[] commandStringArr = commandStr.ToCharArray ();
		for (int i = 0; i < MaxCommandStrLength; i++) {
			commandStringArr [i] = '0';
		}
		commandStr = new string(commandStringArr);
		commandStrIndex = 0;
	}

	public void ReadyListen(){
		timer.ResetTimer ();
	}

	void InvalidMedicineCommand(){
		Debug.Log ("InvalidMedicine!");
	}
}
