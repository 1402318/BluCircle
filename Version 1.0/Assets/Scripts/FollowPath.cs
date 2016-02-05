using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowPath : MonoBehaviour 
{
    public bool activate = false;
	public enum followType//Create values for Enumerator
	{
		MoveTowards,
		Lerp
	}

	public followType Type = followType.MoveTowards;//Make a type for Enumerator
	public PathDefined Path;//Accesses PathDefined Script
	public float speed = 1;//Speed at which the platform will move
	public float MaxDistanceToGoal = .1f;//Distance from which the the platform will stop B4 the point

	private IEnumerator<Transform> _currentPoint;//create point enumerator

	public void Start()
	{
		if (Path == null)//If the path doesn't move, send this message
		{
			Debug.LogError("Path cannot be null", gameObject);
			return;
		}

		_currentPoint = Path.GetPathEnumerator ();// connects current point to PathDefined Enumerator
		_currentPoint.MoveNext();//Initiates movement

		if (_currentPoint.Current == null)
			return;

		transform.position = _currentPoint.Current.position;
	}

	public void Update()
	{
        if (activate == true)
        {
            if (_currentPoint == null || _currentPoint.Current == null)
                return;

            if (Type == followType.MoveTowards)
                transform.position = Vector3.MoveTowards(transform.position, _currentPoint.Current.position, Time.deltaTime * speed);
            else if (Type == followType.Lerp)
                transform.position = Vector3.Lerp(transform.position, _currentPoint.Current.position, Time.deltaTime * speed);

            var distanceSquared = (transform.position - _currentPoint.Current.position).sqrMagnitude;
            if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal)
                _currentPoint.MoveNext();
        }
	}

    public void StartMoving()
    {
        activate = true;
    }

    public void StopMoving()
    {
        activate = false;
    }
}