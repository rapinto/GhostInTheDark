using UnityEngine;
using System.Collections;

enum State {
	Idle = 0,
	Running = 1,
}

public class MoveController : MonoBehaviour {

	//public AnimationClip* idleAnimation;
	//public AnimationClip* runAnimation;
	
	//public int characterState;
	
	public Transform playerBody;
	
	public float runSpeedMax = 1.0f;
	private float runSpeedCurrent = 1.0f;
	private float speedSmoothing = 2.0f;
	private Vector3 moveDirection = Vector3.zero;
	
	private bool isMoving = false;
	public bool isControllable = true;
	
	// Use this for initialization
	void Start () {
	
	}
	void Awake()
	{

		moveDirection = transform.TransformDirection(Vector3.forward);
	
		/*
		_animation = GetComponent(Animation);
		if(!_animation)
			Debug.Log("The character you would like to control doesn't have animations. Moving her might look weird.");
	
		if(!idleAnimation) {
			_animation = null;
			Debug.Log("No idle animation found. Turning off animations.");
		}
		if(!runAnimation) {
			_animation = null;
			Debug.Log("No run animation found. Turning off animations.");
		}
		*/	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isControllable){
			float v = 0.0f;
		    float h = 0.0f;
			v = Input.GetAxisRaw("Vertical");
			h = Input.GetAxisRaw("Horizontal");
			
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
}