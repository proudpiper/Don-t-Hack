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

		Medicine_Reference advair_Ref = new Medicine_Reference (5, Medicine.ActivateAdvair);
		Medicine_Reference albuterol_Ref = new Medicine_Reference (5, Medicine.ActivateAlbuterol);
		Medicine_Reference epinephrine_Ref = new Medicine_Reference (5, Medicine.ActivateEpinephrine);
		Medicine_Reference flonase_Ref = new Medicine_Reference (5, Medicine.ActivateFlonase);
		Medicine_Reference singulair_Ref = new Medicine_Reference (5, Medicine.ActivateSingulair);

		medicineCabinet.Add ("Advari", advair_Ref);
		medicineCabinet.Add ("Albuterol", albuterol_Ref);
		medicineCabinet.Add ("Epinephrine", epinephrine_Ref);
		medicineCabinet.Add ("Flonase", flonase_Ref);
		medicineCabinet.Add ("Singulair", singulair_Ref);

		commandController = transform.FindChild ("DDR_Controller").GetComponent<DDR_Controller> ();
	}

	void Update(){
		runningScript ();
	}

	Action runningScript;

	void Init(){
		commandController.ReadyListen ();
		runningScript = GetCommand;
	}

	void GetCommand(){
		if (Input.GetKeyDown (KeyCode.W)) {
			commandController.AddCommandChar ('W');
		}
		else if (Input.GetKeyDown (KeyCode.A)) {
			commandController.AddCommandChar ('A');
		}
		else if (Input.GetKeyDown (KeyCode.S)) {
			commandController.AddCommandChar ('S');
		}
		else if (Input.GetKeyDown (KeyCode.D)) {
			commandController.AddCommandChar ('D');
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
	}

	void Hold(){
	}

	void EmptyMedicineRequested(){
	}

	void OnTriggerEnter2D(Collider2D collider){
		collider.gameObject.GetComponent<CollidingObject> ().HandleCollision (this);
	}
}
