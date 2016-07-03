using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour{
	DDR_Controller commandController;
	Dictionary<string, Medicine_Reference> medicineCabinet = new Dictionary<string, Medicine_Reference> ();

	public float breath = 100;
	public float visibility = 100;
	public float movement = 100;

	void Start(){
		Medicine.SetupMedicineDereferencer ();

		runningScript = Init;

		Medicine_Reference albuterol_Ref = new Medicine_Reference (5, Medicine.ActivateAlbuterol);
		Medicine_Reference epinephrine_Ref = new Medicine_Reference (5, Medicine.ActivateEpinephrine);
		Medicine_Reference singulair_Ref = new Medicine_Reference (5, Medicine.ActivateSingulair);
		Medicine_Reference tissues_Ref = new Medicine_Reference (5, Medicine.ActivateTissue);

		medicineCabinet.Add ("Albuterol", albuterol_Ref);
		medicineCabinet.Add ("Epinephrine", epinephrine_Ref);
		medicineCabinet.Add ("Singulair", singulair_Ref);
		medicineCabinet.Add ("Tissues", tissues_Ref);

		commandController = transform.FindChild ("DDR_Controller").GetComponent<DDR_Controller> ();
	}

	void Update(){
		runningScript ();
	}

	Action runningScript;

	void Init(){
		//commandController.ReadyListen ();
		runningScript = StandardInput;
	}

	void StandardInput(){
		if (Input.GetKeyDown (InputMapping.upCode)) {
			//Jump
		} 
		else if (Input.GetKeyDown (InputMapping.downCode)) {
			//Duck
		}
		else if (Input.GetKeyDown (InputMapping.albuterolCode)) {
			//Albuterol
			runningScript = GetCommand;
		}
		else if (Input.GetKeyDown (InputMapping.singulairCode)) {
			//Singulair
			runningScript = GetCommand;
		} 
		else if (Input.GetKeyDown (InputMapping.epinephrineCode)) {
			//epinephrine
			runningScript = GetCommand;
		} 
		else if (Input.GetKeyDown (InputMapping.tissueCode)) {
			//tissues
			runningScript = GetCommand;
		}

	}

	void GetCommand(){
		if (Input.GetKeyDown (InputMapping.upCode)) {
			commandController.AddCommandChar (InputMapping.upCode);
		}
		else if (Input.GetKeyDown (InputMapping.leftCode)) {
			commandController.AddCommandChar (InputMapping.leftCode);
		}
		else if (Input.GetKeyDown (InputMapping.downCode)) {
			commandController.AddCommandChar (InputMapping.downCode);
		}
		else if (Input.GetKeyDown (InputMapping.rightCode)) {
			commandController.AddCommandChar (InputMapping.rightCode);
		}
	}

	public void UseMedicine(string medicineName){
		Medicine_Reference medRef;
		if (medicineCabinet.TryGetValue (medicineName, out medRef)) {
			if (medRef.amt > 0) {
				medRef.handler (this);
				--medRef.amt;
			}
		}
		else {
			EmptyMedicineRequested ();
		}

		runningScript = StandardInput;
	}

	void Hold(){
	}

	void EmptyMedicineRequested(){
	}

	void OnTriggerEnter2D(Collider2D collider){
		Debug.Log ("Collision!");
		if (collider.transform.CompareTag ("DamagingObj") == true) {
			Debug.Log ("Found one!");
			collider.gameObject.GetComponent<CollidingObject> ().HandleCollision (this);
		}
		/*
		if(collider == null){
			Debug.Log ("Null Collider");
		}
		if (collider.gameObject == null) {
			Debug.Log ("Null GameObejct");
		}
		if (collider.gameObject.GetComponent<CollidingObject> () == null) {
			Debug.Log ("Null component!");
		}
		*/
	}
}
