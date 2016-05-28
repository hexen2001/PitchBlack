using UnityEngine;
using System.Collections;

public class AIMonster : AIFollowAttack
{

	public bool chaos
	{
		get
		{
			if (m_chaos != m_nextChaos)
			{
				if (m_changeTime < Time.time)
				{
					m_chaos = m_nextChaos;
				}
			}
			return m_chaos;
		}
		set
		{
			if (m_nextChaos != value)
			{
				m_nextChaos = value;
				m_changeTime = Time.time + chaosDelay;
			}
		}
	}

	private bool m_nextChaos = false;
	private bool m_chaos = false;
	public float chaosDelay = 0.5f;
	private float m_changeTime = 0f;

	private float m_resumeTime = 0f;
	protected override void Update ()
	{
		chaos = self.lighting;
		if (self.lighting)
		{
			m_resumeTime = Time.time + chaosDelay;
		}
		
		if (chaos && self is Monster)
		{
			var m = self as Monster;
			if (m != null && m.lighting)
			{ 
				var lightObj = m.lights [m.lights.Count - 1];
				var dir = -(lightObj.transform.position - transform.position).normalized;
				self.nav.Move (dir * self.nav.speed * Time.deltaTime);
				return;
			}
		}


		base.Update ();
	
	}
}
