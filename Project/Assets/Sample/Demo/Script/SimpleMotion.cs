using UnityEngine;
using System.Collections;

public class SimpleMotion : MonoBehaviour
{
	public Vector3 dir = Vector3.forward;
	public float speed = 8;
	public float time = 1f;
	void Start()
	{
		iTween.MoveAdd (gameObject, dir * speed * time, time);
	}
}
