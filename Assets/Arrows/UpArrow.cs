using UnityEngine;
using System;

public class UpArrow : MonoBehaviour{
	Timer timer;
	bool active = false;

	void Start(){
		timer = new Timer (1, HideArrow);
	}

	void Update() {
		if(active){
			ShowArrow ();
		}
	}

	void ShowArrow(){
		//Fire animation
	}

	void HideArrow(){
	}
}

