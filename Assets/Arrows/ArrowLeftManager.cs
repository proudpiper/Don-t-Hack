using UnityEngine;
using System.Collections;

public class ArrowLeftManager : MonoBehaviour {
	public static Action Fire;
	static Animator anim;
	static int triggerHash;

	void Start(){
		Fire = _Fire;
		anim = transform.GetComponent<Animator> ();
		triggerHash = Animator.StringToHash ("Fire");
	}

	void _Fire(){
		anim.SetTrigger (triggerHash);
	}
}
