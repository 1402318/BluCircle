using UnityEngine;
using System.Collections;

public class Puddle : MonoBehaviour {

	ParticleSystem splash;
	public float time;

	void Start(){
		splash = GetComponent<ParticleSystem>();
		time = 0;
	}

	void OnTriggerEnter(Collider other)
	{
		splash.Play ();
	}

	void OnTriggerStay(Collider other)
	{
		time += 1;
		if (other.tag == "Player" && time >=25) {
			Application.LoadLevel(0);
		}
	}

	void OnTriggerEnd(Collider other)
	{
		splash.Stop();
	}



}