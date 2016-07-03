using UnityEngine;

public class AnimalObstacle : Obstacle{
	public override void HandleCollision(Player player){
		player.breath = player.breath - breathDamage;
		player.visibility = player.visibility - visibilityDamage;
		player.maxBreath = player.maxBreath - maxBreathDamage;
	}
}
