using UnityEngine;
using System.Collections;

public class Puddle : MonoBehaviour {

	ParticleSystem splash;
	public float time;
    public Transform puddleRespawnNode; //assigned in the inspecter this should be a child of the puddle prefab

	void Start(){
		splash = GetComponent<ParticleSystem>();
		time = 0;
        if(puddleRespawnNode == null)
        {
            Debug.Log("I have not been assigned a respawn node, I refuse to work without him"); //checks if the node has not been assigned as this will cause an error later in code.
        }
	}

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            Debug.Log(other.gameObject.name); 
        } //a check to find out if another object collides with the puddle. This can be used for logic with rocks or other objects

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<CatMove>().respawnPoint = puddleRespawnNode; //this assigns the Transform respawnPoint on the CatMove script so that it resets whereever the puddle node is.
            splash.Play();
            Debug.Log("oh something splashed in me...");
        }
    }

	void OnTriggerStay(Collider other)
	{
        time += 1 * Time.deltaTime; //make sure if making a timer like this that you use time.delta as this is dependant on the devices frame rate
        //Debug.Log(time);
		if (other.tag == "Player" && time >=0.5) {
			//Application.LoadLevel(0); //this is really in efficent as the assets are already loaded.
            GameObject.FindGameObjectWithTag("Player").GetComponent<CatMove>().ResetPosition(); //This calls ResetPosition() function which will change the Players position in world space to its respawn point vector
            time = 0;
		}
	}

	void OnTriggerEnd(Collider other)
	{

		splash.Stop();
	}



}