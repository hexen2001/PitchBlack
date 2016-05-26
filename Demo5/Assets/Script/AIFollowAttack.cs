using UnityEngine;
using System.Collections;

public class AIFollowAttack : CharacterComponent
{
	private void StopMotion ()
	{
		self.nav.Stop ();
		self.nav.ResetPath ();
	}

	void FollowTarget ()
	{
		self.nav.SetDestination (self.target.transform.position);
	}

	protected void Update()
	{
		//	follow
		if (self.target != null)
		{
			if (self.InFireRange (self.target.transform.position))
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
			StopMotion ();
		}
	}
}
