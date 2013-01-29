using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	
	public Room room1;
	public Room room2;
	
	public Transform doorAudioSource;
	
	public DoorAudioSource myAudioSource;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	void Awake () {
		GameObject doorAudioSourceGO = Instantiate(doorAudioSource.gameObject, this.transform.position, transform.rotation) as GameObject;
		DoorAudioSource aDoorAudioScript = doorAudioSourceGO.GetComponent<DoorAudioSource>();
		myAudioSource = aDoorAudioScript;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
