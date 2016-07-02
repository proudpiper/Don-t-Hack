using UnityEngine;

public class SmogCloud : CollidingObject {
	public override void HandleCollision(Player player){
		player.breath -= 20;
	}
}