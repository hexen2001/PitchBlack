using UnityEngine;
using System.Collections;

public class SimpleMotion : MonoBehaviour
{
	public Vector3 dir = Vector3.forward;
	public float speed = 8;
	void Update()
	{
		transform.position += transform.forward * speed *Time.deltaTime;
	}
}
