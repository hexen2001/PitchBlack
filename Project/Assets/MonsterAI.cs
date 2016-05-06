using UnityEngine;
using System.Collections;

namespace Demo2
{
	public class AIBase : MonoBehaviour
	{
		public Role self
		{
			get{
				return GetComponent<Role> ();
			}
		}
	}

	public class MonsterAI : AIBase
	{
		public void Update()
		{
			if (self.target == null)
			{
				return;
			}

			//	小于某值可攻击
			float distance = (self.target.transform.position
				- self.transform.position).magnitude;
			distance -= (self.bodySize + self.target.bodySize)/2f;
			if (self.weapon.range >= distance )
			{
				var rot = Quaternion.LookRotation (
					          (self.target.transform.position - self.transform.position).normalized,
					          self.transform.up);
				transform.rotation = Quaternion.Slerp( transform.rotation, rot, 0.1f );
				self.Fire ();
			}
			else{
				self.nav.destination = self.target.transform.position;
				self.nav.stoppingDistance = (self.bodySize + self.target.bodySize ) / 2f + self.weapon.range;
			}
		}
	}
}