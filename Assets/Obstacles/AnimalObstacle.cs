using UnityEngine;
using System.Collections.Generic;

public class AnimalObstacle : Obstacle{

	public List<AudioClip> startSounds;

	public override void HandleCollision(Player player){
		player.breath = player.breath - breathDamage;
		player.visibility = player.visibility - visibilityDamage;
		player.breathMax = player.breathMax - breathDamage;
	}

	void Awake() {
		AudioSource audios = this.GetComponent<AudioSource> ();
		audios.clip = startSounds [Random.Range (0, startSounds.Count)];
		audios.Play();
	}
}
