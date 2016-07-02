using UnityEngine;
using System.Collections.Generic;

public class Timer_Manager : MonoBehaviour {

	static List<Timer> activeTimers = new List<Timer>();


	void Update () {
		for (int i = 0; i < activeTimers.Count; i++) {
			activeTimers [i].UpdateTimer ();
		}
	}

	public static void SetTimerActive(Timer timer){
		if (!activeTimers.Contains(timer)) {
			activeTimers.Add (timer);
		}
	}

	public static void UnsetTimerActive(Timer timer){
		activeTimers.Remove (timer);
	}
}