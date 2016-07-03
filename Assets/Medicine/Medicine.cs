using System;
using System.Collections.Generic;
using UnityEngine;

public class Medicine {
	static KeyCode[] albuterolMapping = {
		InputMapping.upCode,
		InputMapping.upCode,
		InputMapping.rightCode,
		InputMapping.rightCode,
		InputMapping.leftCode
	};

	static KeyCode[] singulairMapping = {
		InputMapping.rightCode,
		InputMapping.downCode,
		InputMapping.leftCode,
		InputMapping.upCode,
		InputMapping.rightCode
	};

	static KeyCode[] epinephrinMapping = {
		InputMapping.rightCode,
		InputMapping.rightCode,
		InputMapping.downCode,
		InputMapping.upCode,
		InputMapping.leftCode
	};

	static KeyCode[] tissueMapping = {
		InputMapping.downCode,
		InputMapping.rightCode,
		InputMapping.downCode,
		InputMapping.rightCode,
		InputMapping.upCode
	};

	public static Dictionary<KeyCode[], string> patternDerefernecer = new Dictionary<KeyCode[], string>();
	public static void SetupMedicineDereferencer(){
		patternDerefernecer.Add (albuterolMapping, "Albuterol");
		patternDerefernecer.Add (singulairMapping, "Singulair");
		patternDerefernecer.Add (epinephrinMapping, "Epinephrine");
		patternDerefernecer.Add (tissueMapping, "Tissue");
	}

	public static void ActivateAlbuterol(Player player){
		Debug.Log ("Albuterol");
	}

	public static void ActivateEpinephrine(Player player){
		Debug.Log ("Epinephrine");
	}

	public static void ActivateSingulair(Player player){
		Debug.Log ("Singulair");
	}

	public static void ActivateTissue(Player player){
		Debug.Log ("Tissues");
	}
}

