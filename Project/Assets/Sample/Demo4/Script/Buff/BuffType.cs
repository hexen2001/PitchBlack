using UnityEngine;
using System.Collections;

namespace Demo4
{
	public enum BuffType
	{
		RecoverPowerSpeed,
		BlackDamage,
		Light,
	}
	public abstract  class Buff : MonoBehaviour
	{
		public abstract BuffType type
		{
			get;
		}
		protected Marine marine
		{
			get
			{
				if (null != self && self is Marine )
				{
					return self as Marine;
				}
				return null;
			}
		}
		protected Character self
		{
			get{
				if (null == m_self)
				{
					m_self = transform.GetComponentInParent<Character> ();
				}
				return m_self;
			}
		}
		[SerializeField]
		private Character m_self;
		public void AddRef()
		{
			++m_refCounter;
		}
		public bool Release()
		{
			--m_refCounter;
			if (0 >= m_refCounter)
			{
				Object.Destroy (gameObject);
				return true;
			}
			return false;
		}
		private int m_refCounter = 0;
	}
}