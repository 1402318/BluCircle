using UnityEngine;
using System.Collections;

public class SeeSawController : MonoBehaviour 
{
    public GameObject Rocky;
    public Transform StartPathNode;
    public Transform EndPathNode;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(Rocky != null)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Trajectory>().startpoint = StartPathNode; //Take this objects StartPathNode Transform and assign it to the trajectory component on the player
                GameObject.FindGameObjectWithTag("Player").GetComponent<Trajectory>().endpoint = EndPathNode;     //Take this ibjects EndPathNode Transform and assign it to the trajectory component on the player
                Debug.Log("I am Found");
            }
            //Destroy(RHP);

        }
        /* if the player has collided with the see saw then look for the attached gameobject and destroy it. This should be assigned in the inspector
         This will be changed later so that when the screen is shaken it should fall*/
    }
}
