using UnityEngine;
using System.Collections;

public class rainDamage : MonoBehaviour {
	
	private float oldLifePerSecond;
	
	public float accelartorLifePerSecond = 4.0f;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
					print ("OnTriggerEnter");	

        if(other.gameObject.CompareTag("Player"))
		{
								print ("Player start");	


			
			LifeController lifeController = other.gameObject.GetComponent<LifeController>();
			oldLifePerSecond =  lifeController.lifePerSecond;
			lifeController.lifePerSecond = lifeController.lifePerSecond * accelartorLifePerSecond;
		}
    }
	void OnTriggerExit(Collider other) {
							print ("OnTriggerExit");	

        if(other.gameObject.CompareTag("Player"))
		{
								print ("Player stop");	

			
			LifeController lifeController = other.gameObject.GetComponent<LifeController>();
			lifeController.lifePerSecond = oldLifePerSecond;
		}
    }
}
