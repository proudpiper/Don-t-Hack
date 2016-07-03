using UnityEngine;

public class ObjectSpawner : MonoBehaviour{
	public GameObject objectType;

	public void SpawnObject(){
		Instantiate(objectType, transform.position, transform.rotation);
	}
}