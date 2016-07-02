using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	bool active = false;
	int seconds = 0;
	float timeLeft=0;
	Action timerCompleteHandler;
	
	// Update is called once per frame
	void Update () {
		if(active){
			timeLeft -= Time.deltaTime;
			if (timeLeft <= 0) {
				timerCompleteHandler ();
				active = false;
			}
		}
	}

	public void StartTimer(int seconds, Action handler) {
		this.seconds = seconds;
		this.timerCompleteHandler = handler;
		timeLeft = seconds;
		active = true;
	}

	public void StopTimer(){
		active = false;
	}

	public void ResetTimer(){
		timeLeft = seconds;
		active = true;
	}

	public void SetupTimer(int seconds, Action handler){
		this.seconds = seconds;
		this.timerCompleteHandler = handler;
	}
}
