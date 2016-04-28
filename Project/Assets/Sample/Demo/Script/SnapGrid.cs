using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SnapGrid : MonoBehaviour
{
	public const float gridSize = 1f;
	void Awake()
	{
		if (Application.isPlaying)
		{
			Object.Destroy (this);
		}
	}
	void Update()
	{
		var pos = transform.position;
		pos.x = pos.x % gridSize;
		pos.y = pos.y % gridSize;
		pos.z = pos.z % gridSize;
		transform.position = pos;
	}
}
