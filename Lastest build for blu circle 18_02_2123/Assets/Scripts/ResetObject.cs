using UnityEngine;
using System.Collections;

public class ResetObject : MonoBehaviour {

    public Vector3 StartingRotation; //in the inspector insert the rotation of the object you want it to start from here.
    public Transform ObjectSpawnPoint; 
    public float resetTimer;        //how many seconds should pass until the object is reset.

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Rock")
        {
            Debug.Log("I was hit by a rock");
            ResetObjectCaller();
        }
    }

    void Update()
    {
        //if(Input.GetMouseButtonDown(0))
        //{
        //    ResetObjectCaller();
        //}
    }
    public void ResetRotation()
    {
       // Debug.Log("I have reset my position like a good boySaw");  
        this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        //this.transform.rotation = StartingPosition.transform.rotation;
        this.transform.localRotation = Quaternion.Euler(StartingRotation); //this will reset the rotation of the object it's attached too based on the vector placed in the inspector.
        //Debug.Log(StartingPosition.transform.rotation);
    }

    public void ResetPosition()
    {
        this.gameObject.transform.position = ObjectSpawnPoint.transform.position;
    }

    public void ResetObjectCaller()
    {
        StartCoroutine(ResetObjectCo());
    }

    private IEnumerator ResetObjectCo()
    {
        yield return new WaitForSeconds(resetTimer);

        ResetRotation();
    }
}
