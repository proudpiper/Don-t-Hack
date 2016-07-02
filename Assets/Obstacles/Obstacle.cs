using UnityEngine;
using System.Collections;

public class Obstacle : CollidingObject {

	public float breathDamage;
	public float visibilityDamage;
	public float speed;

	public override void HandleCollision(Player player){
		player.breath = player.breath - breathDamage;
		player.visibility = player.visibility - visibilityDamage;
		Destroy (gameObject);
	}
		
	void Update() {
		this.transform.position = new Vector3 (this.transform.position.x - speed, this.transform.position.y, this.transform.position.z);
	}

	void OnExitTrigger2D(Collider2D collider){
		if (collider.transform.CompareTag ("MainCamera"))
			Destroy (gameObject);
	}
}
