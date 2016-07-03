using UnityEngine;
using System.Collections;

public class DDR_Pattern_Menu : MonoBehaviour {

	static SpriteRenderer spriteRenderer;

	public Sprite albuterolPattern;

	static Sprite _albuterolPattern;

	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();

		_albuterolPattern = albuterolPattern;
	}

	public static void ActivateAlbuterolMenu(){
		spriteRenderer.sprite = _albuterolPattern;
	}

	public static void DeactivateMenu(){
		spriteRenderer.sprite = null;
	}
}
