using UnityEngine;
using System.Collections;

public class CharacterComponent : MonoBehaviour
{
	protected Character self
	{
		get{
			if (null == m_self)
			{
				m_self = GetComponent<Character> ();
			}
			return m_self;
		}
	}
	private Character m_self = null;
}

public class AIFollowAttack : CharacterComponent
{
	protected void Update()
	{
		//	follow
		var target = self.target;
		if (target != null)
		{
			self.nav.SetDestination (target.transform.position);
		}
		else
		{
			self.nav.Stop ();
			self.nav.ResetPath ();
		}
	}
}
