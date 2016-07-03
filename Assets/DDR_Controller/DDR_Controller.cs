using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DDR_Controller : MonoBehaviour{
	const int MaxCommandStrLength = 5;

	void Start(){
		timer = new Timer (1.0f, CheckCommand);
		this.player = transform.parent.GetComponent<Player> ();
	}

	Player player;
	Timer timer;

	//string commandStr;
	string commandStr = "";
	int commandStrIndex = 0;
	string wantedStr = "";

	public void AddCommandChar(KeyCode commandChar){
		if (commandStrIndex < MaxCommandStrLength) {
			commandStr += KeyCodeMapper.KeyCodeToString(commandChar);
			++commandStrIndex;
		}
		if (commandStrIndex == MaxCommandStrLength) {
			CheckCommand ();
		}
	}

	void CheckCommand(){
		timer.StopTimer ();
		Medicine_Reference medicine;
		if (Medicine.patternDerefernecer.TryGetValue (commandStr, out medicine)) {
			if (wantedStr.CompareTo (commandStr) == 0)
				player.UseMedicine (medicine);
			else
				player.InvalidMedicineCommand ();
		}
		else {
			player.InvalidMedicineCommand ();
		}
			
		commandStr = "";
		wantedStr = "";
		commandStrIndex = 0;
	}

	public void ReadyListen(string medicineMapping){
		wantedStr = medicineMapping;
		timer.ResetTimer ();
	}
}
