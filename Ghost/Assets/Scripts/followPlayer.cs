using UnityEngine;
using System.Collections;

public class followPlayer : MonoBehaviour {
	private GameObject player;
	public int rotationSpeed = 3;
	public int moveSpeed = 100;
	public int lifeLooseCoef = 5;
	public bool audioPlaying = false;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 lookAt = player.transform.position - transform.position;
		lookAt.Normalize();
		transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(lookAt), rotationSpeed*Time.deltaTime);
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
	}
	

	  void OnTriggerStay (Collider other)  {
		

		if(other.gameObject.CompareTag("Player"))
		{
	        LifeController lifeController = other.gameObject.GetComponent<LifeController>() as LifeController;
			lifeController.lifeCurrent -= Time.deltaTime * lifeLooseCoef;
			
			if(audioPlaying==false)
			{
				audioPlaying = true;
				audio.Play();
				StartCoroutine(playSound());

			}
		}

		
    }
	
	IEnumerator playSound()
	{

        yield return new WaitForSeconds(1);
		audioPlaying = false;
	}
	
}

