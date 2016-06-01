using UnityEngine;
using System.Collections;

public class GridInput : MonoBehaviour
{
	void OnDrawGizmos()
	{
		var screenPos = Input.mousePosition;
		var ray = Camera.main.ScreenPointToRay( screenPos );
		RaycastHit hit;

		int hitFlag = 1 << (int)Layer.Dialog
					  | 1 << (int)Layer.Terrain;


		if( Physics.Raycast( ray, out hit, 1000, hitFlag ) )
		{
			var pos = new GridPoint( hit.point ).ToVector3();
			var size = new Vector3( GridPoint.GridSize, GridPoint.GridSize, GridPoint.GridSize );

			Gizmos.color = Color.red;
			Gizmos.DrawWireCube( pos, size );

			Gizmos.color = Color.blue;
			pos = hit.point;
			Gizmos.DrawWireCube( pos, size );

		}
	}
}
