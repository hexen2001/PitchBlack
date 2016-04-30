using UnityEngine;
using System.Collections;

public class MoveDir : MonoBehaviour
{
	public Vector3 dir = Vector3.forward;
	public float speed = 8;
	protected virtual void Update()
	{
		transform.position += transform.forward * speed *Time.deltaTime;
	}
}
