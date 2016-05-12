using UnityEngine;
using System.Collections;

namespace Demo4
{
	public enum BuffType
	{
		RecoverPowerSpeed,
		BlackDamage,
	}
	public abstract  class Buff : MonoBehaviour
	{
		public abstract BuffType type
		{
			get;
		}
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
		private Character m_self;
		public void AddRef()
		{
			++m_refCounter;
		}
		public void Release()
		{
			--m_refCounter;
			if (0 >= m_refCounter)
			{
				Object.Destroy (this);
			}
		}
		private int m_refCounter = 0;
	}
}