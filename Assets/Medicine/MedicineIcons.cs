using UnityEngine;
using System.Collections;

public class MedicineIcons : MonoBehaviour {

	SpriteRenderer spriteRenderer;

	public Sprite deactiveSprite;
	public Sprite activeSprite;

	void Start(){
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	public void deactivateSprite() {
		spriteRenderer.sprite = deactiveSprite;
	}

	public void activateSprite() {
		spriteRenderer.sprite = activeSprite;
	}
}
