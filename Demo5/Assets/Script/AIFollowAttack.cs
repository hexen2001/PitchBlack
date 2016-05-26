using UnityEngine;
using System.Collections;

public class AIFollowAttack : AIRangeAttack
{

	protected override void Update()
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
			else
			{
				self.SetMoveDir( targetDir );
			}
		}
		else
		{
			self.StopMove();
		}
	}
}
