using UnityEngine;
using System.Collections;

public class HolyAudioSource : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject LevelManagerGO = GameObject.FindGameObjectWithTag("LevelManager");
		generateLevel manager = LevelManagerGO.GetComponent<generateLevel>();
		gameObject.audio.maxDistance= manager.mapHypotenus;
	}
	
	// Update is called once per frame
	void Update () {			
		GameObject playerGO = GameObject.FindWithTag("Player");
		if(playerGO!=null)
		{
					LifeController liveC = playerGO.GetComponent<LifeController>() as LifeController;
		float distanceToPlayer = Vector3.Distance (transform.position, playerGO.transform.position);
		float percent = distanceToPlayer / audio.maxDistance;
		
       	//audio.volume = 1 - percent;		
		audio.pitch =  ((1 - percent) / 2) + 0.5f;
		}

		//audio.pitch =  (liveC.lifeCurrent / liveC.lifeMax) * 2 + 0.5f;
	}
}
