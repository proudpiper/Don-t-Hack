using UnityEngine;
using System.Collections;

public class Timer {
	bool active = false;
	int seconds = 0;
	float timeLeft=0;
	Action timerCompleteHandler;

	public Timer(int seconds, Action handler){
		this.seconds = seconds;
		this.timerCompleteHandler = handler;
	}

	public void UpdateTimer() {
			timeLeft -= Time.deltaTime;
			if (timeLeft <= 0) {
				timerCompleteHandler ();
			}
	}

	public void StartTimer(int seconds, Action handler) {
		this.seconds = seconds;
		this.timerCompleteHandler = handler;
		timeLeft = seconds;
		Timer_Manager.UnsetTimerActive (this);
	}

	public void StopTimer(){
		Timer_Manager.UnsetTimerActive (this);
	}

	public void ResetTimer(){
		timeLeft = seconds;
		Timer_Manager.SetTimerActive (this);
	}
}
