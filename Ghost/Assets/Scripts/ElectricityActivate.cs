using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ElectricityActivate : MonoBehaviour {
	
	public GameObject electricity1;
	public GameObject electricity2;
	public GameObject electricity3;
	public GameObject electricity4;
	
	
	public GameObject[] electricityList;
	public IList<float> timeElapsed;
	public IList<float> timePause;
	public IList<float> timeEnabled;

	// Use this for initialization
	void Start () {
		
		electricityList = new GameObject[4];
		timeElapsed = new float[4];
		timePause = new float[4];
		timeEnabled = new float[4];
		
		electricityList[0]=electricity1;
		electricityList[1]=electricity2;
		electricityList[2]=electricity3;
		electricityList[3]=electricity4;
		
		for(int i = 0; i<electricityList.Length; ++i)
		{
			timeElapsed[i]=0;
			timePause[i]=Random.Range(1.0f,2.5f);
			timeEnabled[i]=Random.Range(1.0f,2.5f);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		for(int i = 0; i<electricityList.Length; ++i)
		{
			timeElapsed[i]=timeElapsed[i]+Time.deltaTime;
		
			if(timeElapsed[i]>timePause[i] && electricityList[i].active==false)
			{
				electricityList[i].SetActive(true);
				timeElapsed[i] = 0;
			}
			else if(timeElapsed[i]>timeEnabled[i] && electricityList[i].active==true)
			{
				electricityList[i].SetActive(false);
				timeElapsed[i] = 0;
			}
		}
		
	}
}
