using UnityEngine;
using System.Collections;

public class Obstacle : CollidingObject {

	public float breathDamage;
	public float visibilityDamage;
	public float speed;
	public float maxBreathDamage;

	public override void HandleCollision(Player player){
		player.breath = player.breath - breathDamage;
		player.visibility = player.visibility - visibilityDamage;
		player.breathMax = player.breathMax - breathDamage;
		Destroy (gameObject);
	}
		
	void Update() {
		transform.position = Vector3.MoveTowards (transform.position, new Vector3 (this.transform.position.x - speed, this.transform.position.y, this.transform.position.z), Time.deltaTime * speed);
		//this.transform.position = new Vector3 (this.transform.position.x - speed, this.transform.position.y, this.transform.position.z);
	}

	void OnTriggerExit2D(Collider2D collider){
		if (collider.transform.CompareTag ("MainCamera"))
			Destroy (gameObject);
	}
}
