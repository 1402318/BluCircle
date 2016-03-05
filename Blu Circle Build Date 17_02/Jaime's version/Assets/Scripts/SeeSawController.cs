using UnityEngine;
using System.Collections;

public class SeeSawController : MonoBehaviour
{
    public GameObject Rock;
    public Transform StartPathNode;
    public Transform EndPathNode;

    public AudioClip SeesawSound;
    AudioSource audio;
    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Rock != null)
            {
                //StartPathNode = GameObject.FindGameObjectWithTag("Player").GetComponent<Trajectory>().startpoint; //Take this objects StartPathNode Transform and assign it to the trajectory component on the player
                //EndPathNode = GameObject.FindGameObjectWithTag("Player").GetComponent<Trajectory>().endpoint;     //Take this ibjects EndPathNode Transform and assign it to the trajectory component on the player
                //Debug.Log("I am Found");
                audio.PlayOneShot(SeesawSound);

                GameObject start = GameObject.Find("Player");           //Changed these, Unity wasn't happy after cat was imported.
                Trajectory others = (Trajectory)start.GetComponent(typeof(Trajectory));
                others.startpoint = StartPathNode;

                GameObject end = GameObject.Find("Player");
                Trajectory endtraj = (Trajectory)end.GetComponent(typeof(Trajectory));
                endtraj.endpoint = EndPathNode;
            }
            Rock.GetComponent<RockController>().activate = true;
            
        }
        /* if the player has collided with the see saw then look for the attached gameobject and destroy it. This should be assigned in the inspector
         This will be changed later so that when the screen is shaken it should fall*/
    }
}
