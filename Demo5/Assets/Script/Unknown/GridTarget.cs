using UnityEngine;
using System.Collections;

public class GridTarget : GridObj
{
	public Vector3 targetPosition
	{
		get
		{
			return GetGridPos() + transform.forward * GridSize;
		}
	}
	protected void OnDrawGizmos()
	{
		Vector3 volume = Vector3.one * GridSize;
		Gizmos.DrawWireCube( GetGridPos(), volume );
		Gizmos.DrawWireCube( GetGridPos() + transform.forward * GridSize, volume );

	}
}
