using UnityEngine;
using System.Collections;

public class MedicineIcons : MonoBehaviour {

	public Sprite deactiveSprite;
	public Sprite activeSprite;

	public void deactivateSprite() {
		this.GetComponent<SpriteRenderer> ().sprite = deactiveSprite;
	}

	public void activateSprite() {
		this.GetComponent<SpriteRenderer> ().sprite = activeSprite;
	}
}
