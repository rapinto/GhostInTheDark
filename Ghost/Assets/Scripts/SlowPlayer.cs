using UnityEngine;
using System.Collections;

public class SlowPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player"))
		{
			MoveController moveController = other.gameObject.GetComponent<MoveController>();
			moveController.runSpeedMax = moveController.runSpeedMax/2;
		}
    }
	void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Player"))
		{
			MoveController moveController = other.gameObject.GetComponent<MoveController>();
			moveController.runSpeedMax = moveController.runSpeedMax*2;
		}
    }
}
