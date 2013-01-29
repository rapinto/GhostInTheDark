using UnityEngine;
using System.Collections;

public class LifeController : MonoBehaviour {
	
	public Transform lightLife;
	public Transform particleLife;
	public float lifeMax = 120.0f;
	public float lifeMin = 20.0f;
	public float lifePerSecond = 0.5f;
	
	public float lightRangeCoef = 5.0f;
	public float lightIntensityCoef = 0.05f;
	public float lightParticleCoef = 0.4f;
	public float lifeCurrent;
	public float deltaRange = 1.25f;
	
	float random;
	
	// Use this for initialization
	void Start () {
		lifeCurrent = lifeMax;
		random = Random.Range(0.0f, 65535.0f);
	}
	
	// Update is called once per frame
	void Update () {
		float noise = Mathf.PingPong(Time.time, 1.0f);
		
		lightLife.light.range = Mathf.Lerp(100+lifeCurrent * lightRangeCoef, 100+lifeCurrent * lightRangeCoef * deltaRange, noise);
        lightLife.light.intensity = 15+lifeCurrent * lightIntensityCoef;
		
		particleLife.particleSystem.startSize = Mathf.Lerp(lifeCurrent * lightParticleCoef, lifeCurrent * lightParticleCoef * deltaRange, noise);
		lifeCurrent -= lifePerSecond * Time.deltaTime;
		
		if(lifeCurrent < lifeMin)
		{
			lifeCurrent = 0;
			if (PlayerPrefs.GetInt("nbPlayers") == 1)
			{
				Application.LoadLevel("gameOver");
			}
			else
			{
				Application.LoadLevel("youwinPlayer2");
			}
		}
		else if(lifeCurrent>lifeMax)
		{
			lifeCurrent = lifeMax;
		}
	}
}
