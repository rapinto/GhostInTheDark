using UnityEngine;
using System.Collections;


public class Room : MonoBehaviour {
	
	public Door topDoor = null;
	public Door bottomDoor = null;
	public Door leftDoor = null;
	public Door rightDoor = null;
	public HolyDoor holyDoor = null;
	
	
	static public int width = 500;
	static public int height = 500;
	
	public Transform wallPlug;
	public Transform door;
	
	public int posX;
	public int posZ;
	
	public int type;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void addTopPlug () {			
		Vector3 pos = new Vector3(0, 101, -245);
		Instantiate(wallPlug, this.transform.position + pos, transform.rotation * Quaternion.Euler(0, 90, 0));
	}
	
	public void addBottomPlug () {	
		Vector3 pos = new Vector3(0, 101, 245);
		Instantiate(wallPlug, this.transform.position + pos, transform.rotation * Quaternion.Euler(0, 90, 0));
	}
	
	public void addLeftPlug () {		
		Vector3 pos = new Vector3(-245, 101, 0);
		Instantiate(wallPlug, this.transform.position + pos, transform.rotation);
	}
	
	public void addRightPlug () {	
		Vector3 pos = new Vector3(245, 101, 0);	
		Instantiate(wallPlug, this.transform.position + pos, transform.rotation);
	}
	
	public void addTopExit () {	
		Vector3 pos = new Vector3(0, 101, -245);
		Instantiate(holyDoor, this.transform.position + pos, transform.rotation * Quaternion.Euler(0, 270, 0));
	}
	
	public void addBottomExit () {	
		Vector3 pos = new Vector3(0, 101, 245);
		Instantiate(holyDoor, this.transform.position + pos, transform.rotation * Quaternion.Euler(0, 90, 0));
	}
	
	public void addLeftExit () {		
		Vector3 pos = new Vector3(-245, 101, 0);
		Instantiate(holyDoor, this.transform.position + pos, transform.rotation * Quaternion.Euler(0, 0, 0));
	}
	
	public void addRightExit () {	
		Vector3 pos = new Vector3(245, 101, 0);	
		Instantiate(holyDoor, this.transform.position + pos, transform.rotation * Quaternion.Euler(0, 180, 0));
	}
	
	public Door addBottomDoor () {
		Vector3 pos = new Vector3(0, 101, 250);
		GameObject doorGO = Instantiate(door.gameObject, this.transform.position + pos, transform.rotation * Quaternion.Euler(0, 90, 0)) as GameObject;
		Door aDoorScript = doorGO.GetComponent<Door>();
		aDoorScript.room1 = this;
		bottomDoor = aDoorScript;
		return aDoorScript;
		return null;
	}
	
	public void load(int type)
	{
		Vector3 rotation = Vector3.up;

		
		
		GameObject prefabContaint = null;
		GameObject containt = null; 
		switch(type)
		{
			case 0:
			break;
			
			case 1:
				containt = GameObject.Instantiate(Resources.Load("ContaintImpasse_1"),gameObject.transform.position,Quaternion.Euler(Vector3.up)) as GameObject;
			break;	
			
			case 2:
				containt = GameObject.Instantiate(Resources.Load("ContaintImpasse_2"),gameObject.transform.position,Quaternion.Euler(Vector3.up)) as GameObject;
			break;	
			
			case 3:
				containt = GameObject.Instantiate(Resources.Load("ContaintImpasse_3"),gameObject.transform.position,Quaternion.Euler(Vector3.up)) as GameObject;
			break;	
			
			case 4:
				containt = GameObject.Instantiate(Resources.Load("ContaintImpasse_4"),gameObject.transform.position,Quaternion.Euler(Vector3.up)) as GameObject;
			break;
			case 5:
				containt = GameObject.Instantiate(Resources.Load("ContaintRain"),gameObject.transform.position,Quaternion.Euler(Vector3.up)) as GameObject;
			break;	
			case 6:
				containt = GameObject.Instantiate(Resources.Load("ContaintSlow"),gameObject.transform.position,Quaternion.Euler(Vector3.up)) as GameObject;
			break;	
			case 7:
				containt = GameObject.Instantiate(Resources.Load("ContaintTrapElectricity"),gameObject.transform.position,Quaternion.Euler(Vector3.up)) as GameObject;
			break;	
			case 8:
				containt = GameObject.Instantiate(Resources.Load("ContaintEnnemy"),gameObject.transform.position,Quaternion.Euler(Vector3.up)) as GameObject;
			break;	
			case 9:
				containt = GameObject.Instantiate(Resources.Load("ContaintGainLight"),gameObject.transform.position,Quaternion.Euler(Vector3.up)) as GameObject;
			break;
			case 10:
				containt = GameObject.Instantiate(Resources.Load("ContaintVortex"),gameObject.transform.position,Quaternion.Euler(Vector3.up)) as GameObject;
			break;
			
			case 100:
				containt = GameObject.Instantiate(Resources.Load("HolyRoomContaint"),gameObject.transform.position,Quaternion.Euler(Vector3.up)) as GameObject;
			break;	
			
		}
		if(containt!=null)
		{
			int angle = Random.Range(0,4);
			containt.transform.Rotate(new Vector3(0,1,0),90*angle);
		}

	}
	public void addTopDoor (Door newTopDoor) {
		/*topDoor = newTopDoor;
		topDoor.room2 = this;		*/	
	}
	
	public Door addRightDoor () {
		Vector3 pos = new Vector3(250, 101, 0);	
		GameObject doorGO = Instantiate(door.gameObject, this.transform.position + pos, transform.rotation) as GameObject;
		Door aDoorScript = doorGO.GetComponent<Door>();
		rightDoor = aDoorScript;
		aDoorScript.room1 = this;
		return aDoorScript;
	}
	
	public void addLeftDoor (Door newLeftDoor) {
		leftDoor = newLeftDoor;
		leftDoor.room2 = this;		
	}
}
