using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class LaunchPath1 : MonoBehaviour 
{
	public Transform[] Points; // Array for stopping points for platform
	
	public IEnumerator<Transform> GetPathEnumerator()
	{
		if (Points == null || Points.Length < 1) 
		{
			yield break;
		}
		var direction = 1;// moving direction to the right
		var index = 0;// acts as stopping point for direction
		while (true)
		{
			yield return Points[index];//set enumerator to return its property
			
			if(Points.Length == 1)// prevents the platform from either stopping or
			{					  // reaching the end of its path and jumping back to the left
				continue;
			}
			
			if(index <= 0)// Move right
			{
				direction = 1;
			}
			else if(index >= Points.Length -1)// Move left
			{
				direction = 0;
			}
			index = index + direction;
		}
		
	}
	
	public void OnDrawGizmos()// draws lines in scene to see the path that will be taken
	{
		if (Points == null || Points.Length < 2) 
			return;
		
		for(var i = 1; i < Points.Length; i++)
		{
			Gizmos.DrawLine(Points[i -1].position, Points[i].position);
		}
		
	}
}