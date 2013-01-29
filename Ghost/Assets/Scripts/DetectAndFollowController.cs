using UnityEngine;
using System.Collections;

public class DetectAndFollowController : MonoBehaviour {
	
	public bool isMove = false;
	private GameObject player;
	public int moveSpeed = 50;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(isMove) 
		{
			Vector3 v = player.transform.position - transform.position;
			v.Normalize();
			transform.position += v * moveSpeed * Time.deltaTime;
		} 
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="Player")
		{
			player = other.gameObject;
			if(!isMove) 
			{
				audio.Play();
				isMove = true;
			} 
		}
	    
    }
}
