using UnityEngine;
using System.Collections;

namespace Demo4
{
	public class MarineBeHit : MonoBehaviour
	{
		public int damage = 1;
		public Character self;
		public float damageIntervals = 3f;
		private float m_nextHitTime = 0f;

		void StartHit ()
		{
			m_nextHitTime = Time.time + damageIntervals;
		}

		void Update()
		{
			if (m_nextHitTime < Time.time)
			{
				OnDamage ();
				StartHit ();
			}
		}
		void Awake()
		{
			enabled = false;
		}
		void OnEnable()
		{
			StartHit ();
		}
		void OnDamage()
		{
			self.Damage (damage);
		}
	}
}