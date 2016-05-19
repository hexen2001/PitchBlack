using UnityEngine;
using System.Collections.Generic;

namespace Demo4
{
	public class Spwan : MonoBehaviour
	{
		public GameObject prefab;
		public int insCountLimit = 1;
		public int totalCount = 3;
		public float createIntervals = 0f;
		private float m_lastCreateTime;
		private List<GameObject> m_insTable = new List<GameObject> ();
		void Awake()
		{
			if (prefab == null)
			{
				Debug.LogError ("[Spwan]Missing Assets!", gameObject); 
			}
		}
		private int insCount
		{
			get
			{
				return m_insTable.Count;
			}
		}
		private Transform insParent
		{
			get
			{
				return transform;
			}
		}
		private void Create()
		{
			var go = prefab.Create (insParent);
			m_insTable.Add (go);
		}
		private void UpdateClearMissingIns()
		{
			int oriCount = m_insTable.Count;
			m_insTable.Remove (null);
			bool isRemoved = oriCount > m_insTable.Count;
			if (isRemoved)
			{
				if (m_lastCreateTime < Time.time - createIntervals)
				{
					m_lastCreateTime = Time.time;
				}
			}
		}
		void Update()
		{
			UpdateClearMissingIns ();
			while (0 < totalCount && insCount < insCountLimit
				&& m_lastCreateTime + createIntervals <= Time.time)
			{
				m_lastCreateTime = Time.time;
				--totalCount;
				Create ();
			}
		}
	}
}