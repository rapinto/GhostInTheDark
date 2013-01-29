using UnityEngine;
using System.Collections;

public class GenerateLifePoint : MonoBehaviour {
	
	public GameObject pointLight;
	private bool generate = false;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	void OnTriggerEnter()
	{
		if(generate==false)
		{
			generate = true;
			for(int i = 0; i<30; ++i)
			{
				GameObject.Instantiate(pointLight, new Vector3(Random.Range(-200.0f,200.0f),5,Random.Range(-200.0f,200.0f))+gameObject.transform.position,Quaternion.Euler(Vector3.up));
			}			
		}

	}
	// Update is called once per frame
	void Update () {
	
	}
}
