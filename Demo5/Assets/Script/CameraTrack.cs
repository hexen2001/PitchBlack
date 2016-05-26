using UnityEngine;
using System.Collections;

public class CameraTrack : MonoBehaviour
{
	public Transform target;
	void Update()
	{
		if (target != null)
		{
			transform.position = Vector3.Lerp (transform.position, target.position, 0.2f); 
		}
	}
}
