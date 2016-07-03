using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FilterScript : MonoBehaviour {
	Image filter;
	Color color;

	// Use this for initialization
	void Start () {
		filter = GetComponent<Image> ();
		filter.color = new Color (filter.color.r, filter.color.g, filter.color.b, 0.5f);
		//filter.color.a = 0;
	}

	// Update is called once per frame
	void Update () {

	}

	void Dim(){
		
	}

	void UnDim(){
		
	}
}
