using UnityEngine;
using System.Collections;

public class spin : MonoBehaviour
{
	public float speed = 50f;
	
	
	void Update ()
	{
		gameObject.transform.Rotate(Vector3.forward, speed * Time.deltaTime);
	}
}
