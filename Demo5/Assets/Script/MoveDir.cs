using UnityEngine;
using System.Collections;

public class MoveDir : MonoBehaviour
{
	public Vector3 localMotionDir = Vector3.forward;
	public float moveSpeed = 1f;
	protected void Update()
	{
		var worldDir = transform.localToWorldMatrix.MultiplyVector (localMotionDir);
		transform.position += worldDir * moveSpeed * Time.deltaTime;
	}
}
