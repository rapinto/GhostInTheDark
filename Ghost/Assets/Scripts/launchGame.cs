using UnityEngine;
using System.Collections;

public class launchGame : MonoBehaviour {
	
	enum stateCurrent
	{
		kDisplayHome,
		kDisplayHTuto1,
	}

	int currentStatus = 0;
	
	
	bool soloAsked = false;
	bool multiAsked = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Jump") || Input.GetKeyDown("left alt")) {
			
			if (!soloAsked && !multiAsked) {
				if (Input.GetButtonDown ("Jump")) {
					soloAsked = true;
				}
				if (Input.GetKeyDown ("left alt")) {
					multiAsked = true;
				}
			}
			
			switch (currentStatus) {
				case 0: {
					currentStatus = 1;
					displayTuto1ftn();
				}
					break;
				case 1: {
					if (soloAsked) {
						launchSolo();
					}
					else if (multiAsked) {
						launchMulti();
					}
				}
					break;				
			}
		}
	}
	
	void displayTuto1ftn () {
		/*GameObject homeImageGO = GameObject.FindWithTag("HomeImage");
		homeImageGO.guiTexture.enabled = false;*/
		GameObject tuto1ImageGO = GameObject.FindWithTag("Tuto1Image");
		tuto1ImageGO.guiTexture.enabled = true;

		StartCoroutine(launchGameftn());
	}

	
	IEnumerator launchGameftn () {
        yield return new WaitForSeconds(60);
		if (soloAsked) {
			launchSolo();
		}
		else if (multiAsked) {
			launchMulti();
		}
	}
	
	void launchSolo () {
		PlayerPrefs.SetInt("nbPlayers",1);
		Application.LoadLevel ("SceneLevel");
	}
	
	void launchMulti () {
		PlayerPrefs.SetInt("nbPlayers",2);
		Application.LoadLevel("SceneLevel");
	}	
}	

		

		