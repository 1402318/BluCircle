using UnityEngine;
using System.Collections;

public class HopOn : MonoBehaviour {

	public float time;
	public Transform ConnectBase;
	
	void Start()
	{
		time = 0;
		if(ConnectBase == null)
		{
			Debug.Log("I can't do anything without an assignment"); //checks if the node has not been assigned as this will cause an error later in code.
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<CatMove>().sBase = ConnectBase;
		}
	}
	
	void OnTriggerStay(Collider other)
	{
		time += 1 * Time.deltaTime; //make sure if making a timer like this that you use time.delta as this is dependant on the devices frame rate
		if (other.tag == "Player" && time >=0) {
			GameObject.FindGameObjectWithTag("Player").GetComponent<CatMove>().Relocate(); //This calls Reelocate() function which will change the Players position in world space to the swing base
			time = 0;
		}
	}
}
