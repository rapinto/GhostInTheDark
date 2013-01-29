using UnityEngine;
using System.Collections;

public class Vortex : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			GameObject LevelManagerGO = GameObject.FindGameObjectWithTag("LevelManager");
			generateLevel manager = LevelManagerGO.GetComponent<generateLevel>();
			
			int index = Random.Range(0,(int)manager.mapNumberX)+Random.Range(0,(int)manager.mapNumberZ)*manager.mapNumberX;
			Room room = manager.rooms[index];
			other.gameObject.transform.position = room.transform.position;
		}
	}
}
