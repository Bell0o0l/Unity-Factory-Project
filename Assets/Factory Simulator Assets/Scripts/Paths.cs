/*
 * 
 * Developed by Olusola Olaoye, 2023
 * 
 * To only be used by those who purchased from the Unity asset store
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace FactorySimulator
{
	public class Paths : MonoBehaviour
	{

		void OnDrawGizmos()
		{
			Transform[] paths = gameObject.GetComponentsInChildren<Transform>();
			for (int i = 1; i < paths.Length - 1; i++)
			{
				// draw spheres around child transforms
				Gizmos.DrawSphere(paths[i].position, 0.05f);

				// draw line from one child transform to the next
				Gizmos.DrawLine(paths[i].position, paths[i + 1].position);
			}

		}
	}

}