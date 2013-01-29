using UnityEngine;
using System.Collections;

public class lifeIndicator : MonoBehaviour {
	
	public GUITexture backgroundTex;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		LifeController lifeC = player.GetComponent<LifeController>();
		
        guiTexture.pixelInset = new Rect(guiTexture.pixelInset.x,
			guiTexture.pixelInset.y,
			guiTexture.pixelInset.width,
			(backgroundTex.pixelInset.height*(lifeC.lifeCurrent - lifeC.lifeMin))/(lifeC.lifeMax - lifeC.lifeMin));
	}
}
