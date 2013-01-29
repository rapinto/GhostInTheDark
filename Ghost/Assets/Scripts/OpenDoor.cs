using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {
	
	
	
	private bool open = false;
	private bool playAnimationOnDoor = true;

	void Start () {
	
	}
	
	void onTriggerEnter(Collider collider){
       print ("onTriggerEnter");
        
    }
	
	void OnTriggerStay(Collider collider) 
	{
        if (open == false &&
			(collider.gameObject.CompareTag("Player") && Input.GetButton("Jump")) ||
			(collider.gameObject.CompareTag("Ennemy") && Input.GetButton("Jump2")) )
		{
            open = true;
		}
        
    }
	void Update() 
	{
		if(open && transform.position.y > -250)
		{
			if(playAnimationOnDoor){
				
				transform.parent.FindChild("dust").particleEmitter.Emit();
				transform.parent.audio.Play();
				playAnimationOnDoor = false;
			}	
			transform.parent.FindChild("dust").Translate(Vector3.up * Time.deltaTime * 250, Space.World);
       		transform.parent.Translate(Vector3.down * Time.deltaTime * 250, Space.World);
		}
    }
}
