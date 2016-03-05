using UnityEngine;
using System.Collections;

public class RockController : MonoBehaviour
{
    public Vector3 rotateDirection; //in the inspector, insert numbers in the field you want the object to move along i.e x,y,z
    public bool activate = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(activate == true)
        this.gameObject.GetComponent<Rigidbody>().AddTorque(rotateDirection);
    }
    void OnCollisionEnter(Collision other)
    {
        // print("I hit a " + other.gameObject.name);
        if (other.gameObject.tag == "SeeSaw")
        {
            //print("I hit the bloody thing");
            //GameObject player = GameObject.Find("Player");
           // Debug.Log("Cat do your thing!");
            GameObject player = GameObject.Find("Player");

            if (player == null)
            {
                Debug.Log("bitch I can't even see the cube, never mind turn it on");
            }
            //player.GetComponent<Trajectory>().ActivateFlyby();

            Trajectory others = (Trajectory)player.GetComponent(typeof(Trajectory));
            others.ActivateFlyby();
            

            ResetObjectCaller(this.gameObject);
            /*This segment is activated when the rock falls and collides with the SeeSaw tagged object. Two things are activated here
             * first, tell the component Trajectory to execute a function see above
             second, activate a coroutine which will destroy the rock"this" object after a changible amount of time*/
        }
    }

    public void ResetObjectCaller(GameObject ObjectName)
    {
        StartCoroutine(ResetObjectCo(ObjectName));
    }

    private IEnumerator ResetObjectCo(GameObject ObjectName)
    {
        yield return new WaitForSeconds(1);
        this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        this.gameObject.GetComponent<Rigidbody>().transform.rotation = Quaternion.identity;

        activate = false;
        this.gameObject.GetComponent<ResetObject>().ResetPosition();
    }
}
