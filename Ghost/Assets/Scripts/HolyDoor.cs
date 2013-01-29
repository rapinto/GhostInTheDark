using UnityEngine;
using System.Collections;

public class HolyDoor : MonoBehaviour {
		
	private bool isWin = false;
	private Collider player;
	private int MoveUpCoef = 300;
	
	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {	
		if(isWin && player != null){	
			player.transform.Translate(Vector3.up * Time.deltaTime *MoveUpCoef, Space.World);
		}
	}
	
	void OnTriggerStay(Collider collider) 
	{   
		if(collider.CompareTag("Player")){
			player = collider;
			MoveController scriptPlayer = player.gameObject.GetComponent<MoveController>();
			scriptPlayer.isControllable = false;
			isWin = true;
			audio.Play();
			StartCoroutine(goWinScreen());
		}
    }
	
	IEnumerator goWinScreen() {
        yield return new WaitForSeconds(1);
		Application.LoadLevel("youwin");
    }
}
