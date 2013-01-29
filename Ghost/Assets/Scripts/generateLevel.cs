using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ContaintType
{
	kContaintNormal = 0,
	kContaintImpasse_1,
	kContaintImpasse_2,
	kContaintImpasse_3,
	kContaintImpasse_4,
	kContaintRain,
	kContaintSlow,
	kContaintTrapElectricity,
	kContaintEnnemy,
	kContaintGainLight,
	kContaintVortex,
	kContaintHolyContaintRoom = 100
}

public class generateLevel : MonoBehaviour {
	
	public Transform room;
	public Transform door;
	public Transform player;
	public Transform ennemi;

	public float mapHypotenus;
	public bool multiplayer;
	
	public int mapNumberX = 5;
	public int mapNumberZ = 5;
	public Room[] rooms;
	GameObject player1;
	GameObject player2;
	//Door[] doors;
	
	public int[] containtNumber;
	List<int> containtPercent = new List<int>(); 

	// Use this for initialization
	void Start () {
		/*int x = mapNumberX/2;
		int z = mapNumberZ/2;
		Room room = rooms[x+z*mapNumberX];*/
		
	}
	
	void Awake() 
	{
		multiplayer = PlayerPrefs.GetInt("nbPlayers")==2;
		
		for(int i = 0; i<containtNumber.Length; ++i)
		{
			int number = containtNumber[i];
			for(int x = 0; x<number; ++x)
			{				
				containtPercent.Add(i);
			}
		}
		
		int mapWidth = Room.width * mapNumberX;
		int mapHeight = Room.height * mapNumberZ;
		
		mapHypotenus = Mathf.Sqrt(mapWidth * mapWidth + mapHeight * mapHeight);	
		
		rooms = new Room[mapNumberX * mapNumberZ]; 
		Vector2 exitCoordinates = getExitCoordinates();
		
		Door previousHorizontalDoor = null;
		Door previousVerticalDoor = null;
			
		Vector2 holyCoordinates = getHolyCoordinates();
		int holyIndex = (int)(holyCoordinates.y * mapNumberZ + holyCoordinates.x);
		
		Vector2 playerVector = getPlayerCoordinates(holyCoordinates);
		int playerIndex = (int)(playerVector.y * mapNumberZ + playerVector.x);
		Vector2 player2Vector = getPlayerCoordinates(playerVector);
		int player2Index = (int)(player2Vector.y * mapNumberZ + player2Vector.x);
		
		for (int column = 0; column < mapNumberZ ; column++)
		{
			for (int ligne = 0; ligne < mapNumberX ; ligne++)
			{
				Vector3 pos = new Vector3(Room.width * column, 0, Room.height * ligne);
				GameObject aRoom = Instantiate(room.gameObject, pos, transform.rotation) as GameObject;
				Room aRoomScript = aRoom.GetComponent<Room>();
				aRoomScript.posX = ligne;
				aRoomScript.posZ = column;				
				rooms[column * mapNumberX + ligne] = aRoomScript;	
				
				if (holyIndex == column * mapNumberX + ligne)
				{
					aRoomScript.load(100);
				}
				else if (playerIndex == column * mapNumberX + ligne) {
					aRoomScript.load(0);
				}
				else if(player2Index == column * mapNumberX + ligne && multiplayer)
				{
					aRoomScript.load(0);
				}
				else
				{
					int type = containtPercent[Random.Range(0, containtPercent.Count)];
					aRoomScript.load(type);
				}
				
				
				bool isExitMap = false;				
				if (ligne == exitCoordinates.x && column == exitCoordinates.y) {
					isExitMap = true;
				}
				
				if (column == 0) {
					aRoomScript.addLeftPlug();
				}
				else {
					aRoomScript.addTopDoor(previousVerticalDoor);
				}
				
				
				if (column == mapNumberZ - 1) {
					aRoomScript.addRightPlug();
				}
				else {
					previousHorizontalDoor = aRoomScript.addRightDoor();					
				}
				
				
				if (ligne == 0) {
					aRoomScript.addTopPlug();
				}
				else {
					aRoomScript.addLeftDoor(previousHorizontalDoor);
				}
				
				if (ligne == mapNumberX - 1) {		
					aRoomScript.addBottomPlug();
				}
				else {
					previousVerticalDoor = aRoomScript.addBottomDoor();
				}
			}
		}
		
		Room room2 = rooms[playerIndex];
		player1 = GameObject.Instantiate(player, room2.transform.position, Quaternion.Euler(Vector3.up)) as GameObject;
		if(multiplayer)
		{
			GameObject.FindGameObjectWithTag("MainCamera").SetActive(false);

			Room roomPlayer2 = rooms[player2Index];
			player2 = GameObject.Instantiate(ennemi, roomPlayer2.transform.position,  Quaternion.Euler(Vector3.up)) as GameObject;
		}
		else
		{
						GameObject.FindGameObjectWithTag("CameraSplit").SetActive(false);

		}
    }
	
	// Update is called once per frame
	void Update () {
	
	}
	
	Vector2 getExitCoordinates () {
		int XCoord = Random.Range(0, mapNumberX);
		int ZCoord;
		
		if (XCoord == 0 || XCoord == mapNumberX - 1) {
			ZCoord = Random.Range(1, mapNumberZ - 1);
		}
		else {
			ZCoord = Random.Range(0, 2);			
			
			if (ZCoord == 1) {
				ZCoord = mapNumberZ - 1;
			}
		}
		
		return new Vector2 (XCoord, ZCoord);
	}
	
	Vector2 getHolyCoordinates ()
	{
		int holyX = Random.Range(0, mapNumberX);
		int holyZ = Random.Range(0, mapNumberZ);
		
		return new Vector2(holyX, holyZ);
	}
	
	Vector2 getPlayerCoordinates (Vector2 holycordinates) {	
		bool finish = false;
		
		while (!finish) {
			int playerX = Random.Range(0, mapNumberX);
			int playerZ = Random.Range(0, mapNumberZ);
			
			int valueAbs = (int)(Mathf.Abs(holycordinates.x - playerX + holycordinates.y - playerZ));
			if (valueAbs > 2) {
				return new Vector2(playerX,playerZ);
			}
		}
		
		return new Vector2(0,0);
	}

}
