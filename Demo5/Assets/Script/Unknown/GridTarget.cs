using UnityEngine;
using System.Collections;

public class GridTarget : GridObj
{
	public Vector3 targetPosition
	{
		get
		{
			return GetGridPos() + transform.forward * GridPoint.GridSize;
		}
	}
	protected void OnDrawGizmos()
	{
		Vector3 volume = Vector3.one * GridPoint.GridSize;
		Gizmos.DrawWireCube( GetGridPos(), volume );








		Vector3 targetPos = GetGridPos () + transform.forward * GridPoint.GridSize;
		targetPos = new GridPoint (targetPos).ToVector3 ();

		Gizmos.DrawWireCube( targetPos, volume );

		Gizmos.color = new Color (0, 0, 1, 0.3f); 
		Vector3 size;
		size = new Vector3 (1000,0.2f,GridPoint.GridSize);
		Gizmos.DrawCube (targetPos, size);
		size = new Vector3 (GridPoint.GridSize,0.1f,1000);
		Gizmos.DrawCube (targetPos, size);

	}
}
