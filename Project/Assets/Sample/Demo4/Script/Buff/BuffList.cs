using UnityEngine;
using System.Collections.Generic;

namespace Demo4
{
	/// <summary>
	/// 状态的容器
	/// </summary>
	public class BuffList : MonoBehaviour
	{
		public bool HasBuff(BuffType buffType)
		{
			foreach(var buff in m_buffList )
			{
				if (buff.Value.type == buffType)
				{
					return true;
				}
			}
			return false;
		}
		private Dictionary<Buff, Buff> m_buffList
		= new Dictionary<Buff, Buff>();
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
	}
}