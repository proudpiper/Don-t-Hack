using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour{
	DDR_Controller commandController;
	Animator anim;

	public float holdBreathDecMod;
	public float holdBreathIncMod;

	public float breathMax;
	public float breathMaxDec;

	public float breath = 100;
	public float visibility = 100;
	public float movement = 100;
	public Text breathText;
	public Text visibilityText;
	public Text movementText;
	public Text albuterolAmtText;
	public GameObject coughParticle;
	private bool holdingBreath = false;
	private bool canHoldBreath = true;
	private bool isJumping = false;
	private bool isCrouching = false;
	private AudioSource audioSource;

	public GameObject albuterolIcon, epiPenIcon, singulairIcon, tissuesIcon;
	private MedicineIcons albuterolIconManager, epiPenIconManager, singulairIconMangaer, tissuesIconManager; 

	Action runningScript;

	void Start(){
		runningScript = Init;
		commandController = transform.FindChild ("DDR_Controller").GetComponent<DDR_Controller> ();
		anim = GetComponent<Animator> ();
		audioSource = GetComponent<AudioSource> ();

		albuterolIconManager = albuterolIcon.GetComponent<MedicineIcons> ();
		epiPenIconManager = epiPenIcon.GetComponent<MedicineIcons> ();
		singulairIconMangaer = singulairIcon.GetComponent<MedicineIcons> ();
		tissuesIconManager = tissuesIcon.GetComponent<MedicineIcons> ();
	}

	void Update(){
		runningScript ();
	}

	void Init(){
		if(runningScript != null)
			runningScript = StandardInput;
	}

	void StandardInput(){
		if (!isJumping && !isCrouching && !holdingBreath) {
			
			if (Input.GetKeyDown (InputMapping.upCode)) {
				//Jump
				isJumping = true;
				anim.SetTrigger ("jumpAnim");
			} else if (Input.GetKeyDown (InputMapping.downCode)) {
				//Duck
				isCrouching = true;
				this.GetComponent<BoxCollider2D> ().size = new Vector2 (1.4f, 1.5f);
				this.GetComponent<BoxCollider2D> ().offset = new Vector2 (-.1f, -1f);	
			} else if (Input.GetKey (InputMapping.holdBreathCode) && canHoldBreath) {
				holdingBreath = true;
			} else if (Input.GetKeyDown (InputMapping.albuterolCode)) {
				//Albuterol
				DDR_Pattern_Menu.ActivateAlbuterolMenu ();
				albuterolIconManager.deactivateSprite ();
				PrepareGetCommand (Medicine.albuterolMapping);
			} else if (Input.GetKeyDown (InputMapping.singulairCode)) {
				//Singulair
				DDR_Pattern_Menu.ActivateSingulairPattern();
				singulairIconMangaer.deactivateSprite();
				PrepareGetCommand (Medicine.singulairMapping);
			} else if (Input.GetKeyDown (InputMapping.epinephrineCode)) {
				//epinephrine
				DDR_Pattern_Menu.ActivateEpiPenMenu();
				epiPenIconManager.deactivateSprite();
				PrepareGetCommand (Medicine.epinephrinMapping);
			} else if (Input.GetKeyDown (InputMapping.tissueCode)) {
				//tissues
				DDR_Pattern_Menu.ActivateTissuesPatter();
				tissuesIconManager.deactivateSprite();
				PrepareGetCommand (Medicine.tissueMapping);
			}
		} else if (isJumping) {
			if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("Jump")) {
				isJumping = false;
			}

		} else if (isCrouching) {
			if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("Crouch")) {
				isCrouching = false;
				this.GetComponent<BoxCollider2D> ().size = new Vector2 (1.4f, 3.5f);
				this.GetComponent<BoxCollider2D> ().offset = new Vector2 (-.1f, 0f);
			}
		} else if (holdingBreath) {
			if (Input.GetKeyUp (InputMapping.holdBreathCode)) {
				holdingBreath = false;
			} 
			breath -= (holdBreathDecMod * Time.deltaTime);
			if (breath <= 0) {
				breath = 0;
				canHoldBreath = false;
				holdingBreath = false;
				breathMax -= breathMaxDec;
				if(breathMax <= 0)
					SceneManager.LoadScene ("TitleScene");
			}
		}

		if (!holdingBreath && breath < breathMax) {
			breath += (holdBreathIncMod * Time.deltaTime);
			if (breath >= breathMax) {
				breath = breathMax;
				canHoldBreath = true;
			}
		}	

		if (breath <= 0 && !holdingBreath) {
			SceneManager.LoadScene ("TitleScene");
		}

		breathText.text = breath.ToString();
		visibilityText.text = visibility.ToString();
		movementText.text = movement.ToString();
	}

	void PrepareGetCommand(string medicineMapping){
		commandController.ReadyListen (medicineMapping);
		CameraFilter.Dim ();
		Time.timeScale = 0.5f;
		runningScript = GetCommand;
	}

	void LeaveGetCommand(){
		CameraFilter.UnDim ();
		Time.timeScale = 1.0f;
		albuterolIconManager.activateSprite ();
		epiPenIconManager.activateSprite ();
		singulairIconMangaer.activateSprite ();
		tissuesIconManager.activateSprite ();

		DDR_Pattern_Menu.DeactivateMenu ();
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
			if (breath > breathMax) {
				breath = breathMax;
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
		if ((collider.transform.CompareTag ("DamagingObj") == true || collider.transform.CompareTag("Animal") == true)&& holdingBreath == false) {
			collider.gameObject.GetComponent<CollidingObject> ().HandleCollision (this);
			audioSource.Play ();
		}
	}

	public  void AlbuterolUpdateCallback(int value){
		albuterolAmtText.text = value.ToString();
	}
}