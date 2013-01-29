using UnityEngine;
using System.Collections;

public class LowLife : MonoBehaviour {
	
	public Color baseColor;
	// Use this for initialization
	void Start () {
		baseColor = guiTexture.color;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		LifeController lifeC = player.GetComponent<LifeController>();
		float life = lifeC.lifeCurrent/lifeC.lifeMax;
		
					print (life );

		if(life <0.5)
		{
			float t = Mathf.PingPong(Time.time*2.0f, 1.0f);
			guiTexture.color = Color.Lerp(baseColor,Color.red,t);	
		}
		else
		{
			guiTexture.color = baseColor;
		}		
	}
}
