using UnityEngine;
using System.Collections;

public class RockController : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision other)
    {
       // print("I hit a " + other.gameObject.name);
        if(other.gameObject.tag == "SeeSaw")
        {
            print("I hit the bloody thing");
            GameObject player = GameObject.Find("Debugging Cube");
            Debug.Log("Cat do your thing!");
            if(player == null)
            {
                Debug.Log("bitch I can't even see the cube, never mind turn it on");
            }
            player.GetComponent<Trajectory>().ActivateFlyby();
            DestroyObjectCaller(this.gameObject);
            /*This segment is activated when the rock falls and collides with the SeeSaw tagged object. Two things are activated here
             * first, tell the component Trajectory to execute a function see above
             second, activate a coroutine which will destroy the rock"this" object after a changible amount of time*/
        }
    }

    public void DestroyObjectCaller(GameObject ObjectName)
    {
        StartCoroutine(DestroyObjectCo(ObjectName));
    }

    private IEnumerator DestroyObjectCo(GameObject ObjectName)
    {
        yield return new WaitForSeconds(1);

        DestroyObject(ObjectName);
    }
}
