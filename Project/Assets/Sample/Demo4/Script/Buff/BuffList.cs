using UnityEngine;
using System.Collections.Generic;

namespace Demo4
{
	/// <summary>
	/// 状态的容器
	/// 状态投射器为容器增删状态
	/// </summary>
	public class BuffList : MonoBehaviour
	{
		public ItemBag items = new ItemBag();

		/// <summary>
		/// 添加某状态
		/// </summary>
		/// <param name="prefab"></param>
		public void AddBuff(Buff prefab)
		{
			Buff ins;
			if (m_buffList.ContainsKey (prefab))
			{
				ins = m_buffList [prefab];
			}
			else
			{
				var go = Object.Instantiate (prefab.gameObject) as GameObject;
				go.transform.parent = transform;
				ins = go.GetComponent<Buff> ();
				m_buffList.Add (prefab, ins);
			}
			ins.AddRef ();
		}

		/// <summary>
		/// 移除某状态
		/// </summary>
		/// <param name="prefab"></param>
		public void RemoveBuff(Buff prefab)
		{
			if (m_buffList.ContainsKey (prefab))
			{
				if (m_buffList [prefab].Release ())
				{
					m_buffList.Remove (prefab);
				}
			}
		}

		/// <summary>
		/// 是否有某状态
		/// </summary>
		/// <returns><c>true</c> if this instance has buff the specified prefab; otherwise, <c>false</c>.</returns>
		/// <param name="prefab">Prefab.</param>
		public bool HasBuff(Buff prefab)
		{
			return m_buffList.ContainsKey (prefab);
		}

		/// <summary>
		/// 所有状态表
		/// key为prefab
		/// value为实例
		/// </summary>
		private Dictionary<Buff, Buff> m_buffList
		= new Dictionary<Buff, Buff>();
	}
}