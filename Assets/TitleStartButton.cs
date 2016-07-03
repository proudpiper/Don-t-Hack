using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleStartButton : MonoBehaviour {

	void OnMouseDown() {
		SceneManager.LoadScene ("MainScene");
	}

}
