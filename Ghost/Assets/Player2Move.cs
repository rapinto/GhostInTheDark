using UnityEngine;
using System.Collections;

public class Player2Move : MonoBehaviour {

	public Transform playerBody;
	
	public float runSpeedMax = 1.0f;
	private float runSpeedCurrent = 1.0f;
	private float speedSmoothing = 2.0f;
	private Vector3 moveDirection = Vector3.zero;
	
	private bool isMoving = false;
	public bool isControllable = true;
	
	public int rotationSpeed = 3;
	public int moveSpeed = 100;
	public int lifeLooseCoef = 5;
	public bool audioPlaying = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(isControllable){
			float v = 0.0f;
		    float h = 0.0f;
			v = Input.GetAxisRaw("Vertical2");
			h = Input.GetAxisRaw("Horizontal2");
			
			if (v != 0.0f || h != 0.0f)
			{
				Vector3 move = new Vector3(h,0,v);
				move.Normalize();
				transform.Translate(move * Time.deltaTime*runSpeedMax);
				isMoving = Mathf.Abs (h) > 0.1 || Mathf.Abs (v) > 0.1;
	
				playerBody.forward = - 1 * move * Time.deltaTime*runSpeedMax;
			}
		}
	}
	

	  void OnTriggerStay (Collider other)  {
		

		if(other.gameObject.CompareTag("Player"))
		{
						print ("test");

	        LifeController lifeController = other.gameObject.GetComponent<LifeController>() as LifeController;
			lifeController.lifeCurrent -= lifeLooseCoef;
			
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
