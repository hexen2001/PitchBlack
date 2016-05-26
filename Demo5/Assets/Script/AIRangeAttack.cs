using UnityEngine;
using System.Collections;

public class AIRangeAttack : CharacterComponent
{
	protected Vector3 targetDir
	{
		get
		{
			if( self.target != null )
			{
				var dir = self.target.transform.position - transform.position;
				dir.y = 0f;
				return dir.normalized;
			}
			return Vector3.forward;
		}
	}

	protected void RotateAtTarget()
	{
		transform.rotation = Quaternion.Slerp
			( transform.rotation, Quaternion.LookRotation( targetDir, Vector3.up ), 0.2f );
	}

	protected virtual void Update()
	{
		//	follow
		if( self.target != null )
		{
			RotateAtTarget();

			if( self.CheckFireRange( self.target.transform.position ) )
			{
				if( self.gun.isCanFire )
				{
					self.Fire();
				}
			}
		}
	}
}
