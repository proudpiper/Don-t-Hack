using System;
using System.Collections.Generic;
using UnityEngine;

public class Medicine {
		
	public static Dictionary<string, string> patternDerefernecer = new Dictionary<string, string>();
	public static void SetupMedicineDereferencer(){
		patternDerefernecer.Add ("WWDDA", "Flonase");
		patternDerefernecer.Add ("SSDWA", "Albuterol");
		patternDerefernecer.Add ("WDASW", "Advair");
		patternDerefernecer.Add ("DSAWD", "Singulair");
		patternDerefernecer.Add ("DDSWA", "Epinephrine");
	}

	public static void ActivateAdvair(Player player){
		Debug.Log ("Advair!");
	}

	public static void ActivateAlbuterol(Player player){
		Debug.Log ("Albuterol");
	}

	public static void ActivateEpinephrine(Player player){
		Debug.Log ("Epinephrine");
	}

	public static void ActivateFlonase(Player player){
		Debug.Log ("Flonase");
	}

	public static void ActivateSingulair(Player player){
		Debug.Log ("Singulair");
	}
}

