using UnityEngine;
using System.Collections;

public class Timer {
	bool active = false;
	float seconds = 0;
	float timeLeft=0;
	Action timerCompleteHandler;

	public Timer(float seconds, Action handler){
		this.seconds = seconds;
		this.timerCompleteHandler = handler;
	}

	public Timer(){}

	public void UpdateTimer() {
			timeLeft -= Time.deltaTime;
			if (timeLeft <= 0) {
				timerCompleteHandler ();
				Timer_Manager.UnsetTimerActive (this);
			}
	}

	public void StartTimer(float seconds, Action handler) {
		this.seconds = seconds;
		this.timerCompleteHandler = handler;
		timeLeft = seconds;
		Timer_Manager.SetTimerActive (this);
	}

	public void StopTimer(){
		Timer_Manager.UnsetTimerActive (this);
	}

	public void ResetTimer(){
		timeLeft = seconds;
		Timer_Manager.SetTimerActive (this);
	}
}
