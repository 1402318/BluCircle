using UnityEngine;
using System.Collections;

public class HopOn : MonoBehaviour {

	public float time;
	public Transform SwingConnect;
	
	void Start()
	{
		time = 0;
		if(SwingConnect== null)
		{
			Debug.Log("I can't do anything without an assignment"); //checks if the node has not been assigned as this will cause an error later in code.
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<CatMove>().sBase = SwingConnect;
		}
	}

    void OnTriggerStay(Collider other)
    {
        time += 1 * Time.deltaTime; //make sure if making a timer like this that you use time.delta as this is dependant on the devices frame rate
        if (other.tag == "Player" && time >= 0)
        {
            var player = GameObject.Find("Player");
            Debug.Log(player);
            if (player.GetComponent<CatMove>() == null)
                Debug.Log("I cant find that component");
            player.GetComponent<CatMove>().SwingCall = true; //This calls Reelocate() function which will change the Players position in world space to the swing base
            time = 0;
        }
    }
}
