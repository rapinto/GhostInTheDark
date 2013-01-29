using UnityEngine;
using System.Collections;

public class TimeElapsed : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = System.String.Format ("{0:00}:{1:00}", (int)Time.timeSinceLevelLoad/60, (int)Time.timeSinceLevelLoad%60);
	}
}
