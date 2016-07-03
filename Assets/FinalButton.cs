using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FinalButton : MonoBehaviour {

	public void GoToStart() {
		SceneManager.LoadScene ("TitleScene");
	}
}
