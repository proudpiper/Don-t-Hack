using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Player : MonoBehaviour{
	DDR_Controller commandController;
	Animator anim;

	public float breath = 100;
	public float visibility = 100;
	public float movement = 100;
	public Text breathText;
	public Text visibilityText;
	public Text movementText;
	public Text albuterolAmtText;
	public GameObject coughParticle;
	private bool holdingBreath = false;
	public float maxBreath = 100;
	public GameObject albuterolIcon;
	private bool isJumping = false;
	private bool isCrouching = false;

	Action runningScript;

	void Start(){
		runningScript = Init;
		commandController = transform.FindChild ("DDR_Controller").GetComponent<DDR_Controller> ();
		anim = GetComponent<Animator> ();
	}

	void Update(){
		runningScript ();
	}

	void Init(){
		if(runningScript != null)
			runningScript = StandardInput;
	}

	void StandardInput(){
		if (!isJumping && !isCrouching) {
			if (Input.GetKeyDown (InputMapping.upCode)) {
				//Jump
				isJumping = true;
			} else if (Input.GetKeyDown (InputMapping.downCode)) {
				//Duck
				isCrouching = true;
			} else if (Input.GetKey (InputMapping.holdBreathCode)) {
				holdingBreath = true;
			} else if (Input.GetKeyUp (InputMapping.holdBreathCode)) {
				holdingBreath = false;
			} else if (Input.GetKey (InputMapping.crouchCode)) {
				this.GetComponent<BoxCollider2D> ().size = new Vector2 (1.4f, 1.5f);
				this.GetComponent<BoxCollider2D> ().offset = new Vector2 (-.1f, -1f);	
			} else if (Input.GetKeyUp (InputMapping.crouchCode)) {
				this.GetComponent<BoxCollider2D> ().size = new Vector2 (1.4f, 3.5f);
				this.GetComponent<BoxCollider2D> ().offset = new Vector2 (-.1f, 0f);
			} else if (Input.GetKey (InputMapping.jumpCode)) {
				this.GetComponent<BoxCollider2D> ().size = new Vector2 (1.4f, 1.5f);
				this.GetComponent<BoxCollider2D> ().offset = new Vector2 (-.1f, 1f);
			} else if (Input.GetKeyUp (InputMapping.jumpCode)) {
				this.GetComponent<BoxCollider2D> ().size = new Vector2 (1.4f, 3.5f);
				this.GetComponent<BoxCollider2D> ().offset = new Vector2 (-.1f, 0f);
			} else if (Input.GetKeyDown (InputMapping.albuterolCode)) {
				//Albuterol
				albuterolIcon.GetComponent<MedicineIcons> ().deactivateSprite ();
				PrepareGetCommand (Medicine.albuterolMapping);
			} else if (Input.GetKeyDown (InputMapping.singulairCode)) {
				//Singulair
				PrepareGetCommand (Medicine.singulairMapping);
			} else if (Input.GetKeyDown (InputMapping.epinephrineCode)) {
				//epinephrine
				PrepareGetCommand (Medicine.epinephrinMapping);
			} else if (Input.GetKeyDown (InputMapping.tissueCode)) {
				//tissues
				PrepareGetCommand (Medicine.tissueMapping);
			}
		} else if (isJumping) {
			if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("Jump"))
				isJumping = false;
		} else if (isCrouching) {
			if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("Crouch"))
				isCrouching = false;
		}


		breathText.text = breath.ToString();
		visibilityText.text = visibility.ToString();
		movementText.text = movement.ToString();

	}

	void PrepareGetCommand(string medicineMapping){
		commandController.ReadyListen (medicineMapping);
		Time.timeScale = 0.5f;
		runningScript = GetCommand;
	}

	void LeaveGetCommand(){
		Time.timeScale = 1.0f;
		albuterolIcon.GetComponent<MedicineIcons>().activateSprite ();
		runningScript = StandardInput;
	}

	void GetCommand(){
		if (Input.GetKeyDown (InputMapping.upCode)) {
			ArrowUpManager.Fire ();
			commandController.AddCommandChar (InputMapping.upCode);
		}
		else if (Input.GetKeyDown (InputMapping.leftCode)) {
			ArrowLeftManager.Fire ();
			commandController.AddCommandChar (InputMapping.leftCode);
		}
		else if (Input.GetKeyDown (InputMapping.downCode)) {
			ArrowDownManager.Fire ();
			commandController.AddCommandChar (InputMapping.downCode);
		}
		else if (Input.GetKeyDown (InputMapping.rightCode)) {
			ArrowRightManager.Fire ();
			commandController.AddCommandChar (InputMapping.rightCode);
		}
	}

	public void UseMedicine(Medicine_Reference medicine){
		if (medicine.amt > 0) {
			--medicine.amt;
			breath += medicine.breathAffect;
			if (breath > maxBreath) {
				breath = maxBreath;
			}
		}
		else {
			EmptyMedicineRequested ();
		}

		LeaveGetCommand ();
	}

	void EmptyMedicineRequested(){
		LeaveGetCommand ();
	}

	public void InvalidMedicineCommand(){
		Debug.Log ("InvalidMedicine!");
		Vector3 coughPosition = new Vector3 (this.transform.position.x, this.transform.position.y + 1, 0);
		Instantiate (coughParticle, coughPosition, coughParticle.transform.rotation);
		LeaveGetCommand ();
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.transform.CompareTag ("DamagingObj") == true && holdingBreath == false) {
			collider.gameObject.GetComponent<CollidingObject> ().HandleCollision (this);
		}
	}

	public  void AlbuterolUpdateCallback(int value){
		albuterolAmtText.text = value.ToString();
	}
}
