using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	public Transform Player;
	//public AudioClip BackgroundMusic;

	public Vector2 
		Margin,
		Smoothing;

	public BoxCollider2D Bounds;

	private Vector3
		_min,
		_max;

	public bool IsFollowing { get; set; }

	public void Start()
	{
		_min = Bounds.bounds.min;
		_max = Bounds.bounds.max;
		IsFollowing = true;
		//AudioSource.PlayClipAtPoint(BackgroundMusic, transform.position);
	}

	public void Update()
	{
        var x = transform.position.x;
        var y = transform.position.y;

        if (IsFollowing)
        {
            if (Mathf.Abs(x - Player.position.x) > Margin.x)
                x = Mathf.Lerp(x, Player.position.x, Smoothing.x * Time.deltaTime);

            if (Mathf.Abs(y - Player.position.y) > Margin.y)
                y = Mathf.Lerp(y, Player.position.y, Smoothing.y * Time.deltaTime);
        }
		var cameraHalfWidth = GetComponent<Camera>().orthographicSize * ((float)Screen.width / Screen.height);
		
		x = Mathf.Clamp (x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
		y = Mathf.Clamp (y, _min.y + GetComponent<Camera>().orthographicSize, _max.y - GetComponent<Camera>().orthographicSize);
		
		transform.position = new Vector3 (x,y, transform.position.z);
	}
}
/*
 * this script is attacted to the main camera in the scene
 * it gets the position of the player and follows it.
 * it also stays within set boundaraies which are set inside a box collider so that the camera doesn't show assests it shouldn't
 * Smoothing can be changed so that when the player is moving and the camera position is being updated 
 * it can do it in a smooth way but must be adjusted freely depending on player movement speed.
 * */
