using UnityEngine;
using System.Collections;

public class CamMove : MonoBehaviour {

	public float smoothTime ;
	private Vector3 velocity;
	public Transform target;
	public Camera cameraFollow;
	public float cameraX,cameraY, cameraZ;

	// Use this for initialization
	void Start () {
		smoothTime = 0.15f;
		velocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if (target) {

			Vector3 point = cameraFollow.WorldToViewportPoint (target.position);	//Viewport space is normalized and relative to the camera
			Vector3 delta = target.position - cameraFollow.ViewportToWorldPoint (new Vector3 (cameraX, cameraY, cameraZ));	//take away the transform needed from viewport to world
			Vector3 destination = transform.position + delta;		//final point
			transform.position = Vector3.SmoothDamp (transform.position, destination, ref velocity, smoothTime);	//how it gets from one point to another
		}
			//transform.position = Vector3.SmoothDamp (transform.position, destination, ref velocity, smoothTime);


		}

}
