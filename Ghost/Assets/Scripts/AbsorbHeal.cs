using UnityEngine;
using System.Collections;

public class AbsorbHeal : MonoBehaviour {
	
	public float gainLifePoint = 4.0f;
	public GameObject me;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag=="Player")
		{
			LifeController lifeController = other.gameObject.GetComponent<LifeController>();
			lifeController.lifeCurrent += gainLifePoint;
			Destroy(me);
		}
	}
}
