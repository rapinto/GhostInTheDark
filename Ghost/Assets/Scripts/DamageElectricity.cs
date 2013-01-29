using UnityEngine;
using System.Collections;

public class DamageElectricity : MonoBehaviour {
	
	public float electricityDamage = 15.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerStay(Collider other)
	{
		print (other.gameObject.tag);
		if(other.gameObject.CompareTag("Player"))
		{
			LifeController lifeController = other.gameObject.GetComponent<LifeController>();
			lifeController.lifeCurrent-=electricityDamage;
		}
	}
	// Update is called once per frame
	void Update ()
	{
	
	}
}
