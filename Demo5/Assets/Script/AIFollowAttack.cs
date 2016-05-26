using UnityEngine;
using System.Collections;

public class AIFollowAttack : CharacterComponent
{
	private void FollowTarget ()
	{
		self.SetMoveDir (moveDir);
	}

	private Vector3 moveDir
	{
		get{
			if (self.target != null)
			{
				var dir = self.target.transform.position - transform.position;
				return dir.normalized;
			}
			return Vector3.forward;
		}
	}

	void RotateAtTarget ()
	{
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (moveDir, Vector3.up), 0.2f);
	}

	protected void Update()
	{
		//	follow
		if (self.target != null)
		{
			RotateAtTarget ();
			
			if (self.CheckFireRange (self.target.transform.position))
			{
				if (self.gun.isCanFire)
				{
					Debug.Log ("Fire");
					self.Fire ();
				}
			}
			else
			{
				FollowTarget ();
			}
		}
		else
		{
			self.StopMove ();
		}
	}
}
