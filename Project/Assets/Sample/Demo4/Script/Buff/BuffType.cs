using UnityEngine;
using System.Collections;

namespace Demo4
{
	/// <summary>
	/// 状态基类
	/// </summary>
	public abstract class Buff : MonoBehaviour
	{


		#region 关于所处环境
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
		private Character m_self;
		#endregion


		#region 引用计数
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
		#endregion


	}
}