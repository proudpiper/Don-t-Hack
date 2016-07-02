using UnityEngine;

public class PollenCloud : CollidingObject {
	public override void HandleCollision(Player player){
		player.breath -= 20;
	}
}
