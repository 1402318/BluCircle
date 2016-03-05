using UnityEngine;
using System.Collections;

public class MovingPlatformController : MonoBehaviour
{
    public GameObject BrotherPlatform;

    void Start()
    {
        if(BrotherPlatform == null)
        {
            Debug.Log("I will not work without my Brother with me");
        }
    }
	
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Player")
        {
            Debug.Log(other.gameObject.name);
        }
        if(other.gameObject.tag == "Player")
        {
            BrotherPlatform.GetComponent<FollowPath>().StartMoving(); //activate gameobjects function, which causes it start moving the platform.
        }
    }
}
