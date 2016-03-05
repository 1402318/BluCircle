using UnityEngine;
using System.Collections;

public class Trajectory : MonoBehaviour
{
    public Transform startpoint;
    public Transform endpoint;
    Vector3 startPos = new Vector3(0, 0, 0);
    Vector3 endPos = new Vector3(0, 0, 10);
    float trajectoryHeight = 5;
    public bool activate = false;
    float cTime;
 
    void Start()
    {
        Debug.Log("hi, I am called Trajectory");
       // startPos = new Vector3(startpoint.position.x, startpoint.position.y, startpoint.position.z);    //this should be changed so that when the player hits the see saw it finds the startpoint
       //endPos = new Vector3(endpoint.position.x, endpoint.position.y, endpoint.position.z);            //this should be changed so that when the player hits the see saw it find the endpoint
    }
    // Update is called once per frame
    void Update()
    {
        if (activate == true)
        {
            // calculate current time within our lerping time range
            cTime += Time.deltaTime;
            //Debug.Log(cTime);
            // calculate straight-line lerp position:
            Vector3 currentPos = Vector3.Lerp(startPos, endPos, cTime);
            // add a value to Y, using Sine to give a curved trajectory in the Y direction
            currentPos.y += trajectoryHeight * Mathf.Sin(Mathf.Clamp01(cTime) * Mathf.PI);
            // finally assign the computed position to our gameObject:
            transform.position = currentPos;
        }
    }

    public void ActivateFlyby()
    {
        startPos = new Vector3(startpoint.position.x, startpoint.position.y, startpoint.position.z);    //This should already be assigned before this function is called by the SeeSaw Controller script
        endPos = new Vector3(endpoint.position.x, endpoint.position.y, endpoint.position.z);            //This should already be assigned before this function is called by the SeeSaw Controller script
        activate = true;
    }
    public void DeactivateFlyby()
    {
        cTime = 0;
        activate = false;
    }
}
