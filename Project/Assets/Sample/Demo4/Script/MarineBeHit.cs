using UnityEngine;
using System.Collections;

namespace Demo4
{
	public class MarineBeHit : MonoBehaviour
	{
		public int damage = 1;
		public Character self;
		public float damageIntervals = 3f;
		private float m_nextHitTime;
		void Awake()
		{
			enabled = false;
		}
		void OnEnable()
		{
			InvokeRepeating ("OnDamage", damageIntervals, damageIntervals);
		}
		void OnDamage()
		{
			self.Damage (damage);
		}
	}
}