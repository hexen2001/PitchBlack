using UnityEngine;
using System.Collections;

namespace Demo4
{
	public class BuffAdd : Buff
	{
		public ItemType valueType = ItemType.Hp;
		public int value = 0;
		public int minValueLimit = 0;
		public ItemType maxValueLimitType = ItemType.Unknown;
		public float intervals = 1f;
		private float m_nextAddTime = 0f;

		void Update()
		{
			if (m_nextAddTime < Time.time)
			{
				m_nextAddTime = Time.time + intervals;
				self.AddValue (valueType, value, maxValueLimitType);
			}
		}
	}
}