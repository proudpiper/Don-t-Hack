using UnityEngine;
using System.Collections;

public class DDR_Pattern_Menu : MonoBehaviour {

	static SpriteRenderer spriteRenderer;

	public Sprite albuterolPattern;
	public Sprite epiPenPattern;
	public Sprite singulairPattern;
	public Sprite tissuesPattern;

	static Sprite _albuterolPattern;
	static Sprite _epiPenPattern;
	static Sprite _singulairPattern;
	static Sprite _tissuesPattern;

	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();

		_albuterolPattern = albuterolPattern;
		_epiPenPattern = epiPenPattern;
		_singulairPattern = singulairPattern;
		_tissuesPattern = tissuesPattern;
	}

	public static void ActivateAlbuterolMenu(){
		spriteRenderer.sprite = _albuterolPattern;
	}

	public static void ActivateEpiPenMenu(){
		spriteRenderer.sprite = _epiPenPattern;
	}

	public static void ActivateSingulairPattern(){
		spriteRenderer.sprite = _singulairPattern;
	}

	public static void ActivateTissuesPatter(){
		spriteRenderer.sprite = _tissuesPattern;
	}

	public static void DeactivateMenu(){
		spriteRenderer.sprite = null;
	}
}
