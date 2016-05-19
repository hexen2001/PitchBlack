using UnityEngine;
using System.Collections.Generic;

namespace Demo4
{
	public class Vision : MonoBehaviour
	{
		public GameObject target
		{
			get{
				if (0 < m_targets.Count)
				{
					if (m_targets [0] != null)
					{
						return m_targets [0].gameObject;
					}
				}
				return null;
			}
		}
		[SerializeField]
		private List<Transform> m_targets = new List<Transform>();
		protected void OnTriggerEnter(Collider collider)
		{
			m_targets.Add (collider.transform);
		}
		protected void OnTriggerExit(Collider collider)
		{
			m_targets.Remove (collider.transform);
		}
		void Update()
		{
			m_targets.Remove (null);
			m_targets.Sort (SortByDistance);
		}
		public int SortByDistance(Transform a, Transform b)
		{
			return
			(a.position - transform.position).sqrMagnitude
			< (b.position - transform.position).sqrMagnitude ?
			-1 : 1;
		
		}
		void OnDrawGizmos()
		{
			if (target != null)
			{
				Gizmos.color = Color.yellow;
				Gizmos.DrawLine (transform.position, target.transform.position);
			}
		}
	}
}
