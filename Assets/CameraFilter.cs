using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraFilter : MonoBehaviour {
	static Image filter;
	static Action runningScript;

	void Start () {
		filter = GetComponent<Image> ();
		filter.color = new Color (filter.color.r, filter.color.g, filter.color.b, 0.0f);
	}
		
	void Update () {
		if (runningScript != null)
			runningScript();
	}

	static void _Dim(){
		
	}

	static void _UnDim(){
		
	}

	public static void Dim(){
		filter.color = new Color (filter.color.r, filter.color.g, filter.color.b, 0.75f);
		runningScript = _Dim;
	}

	public static void UnDim(){
		filter.color = new Color (filter.color.r, filter.color.g, filter.color.b, 0.0f);
		runningScript = _UnDim;
	}
}
