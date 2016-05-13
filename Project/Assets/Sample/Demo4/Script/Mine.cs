using UnityEngine;
using System.Collections;

namespace Demo4
{
	public class Mine : MonoBehaviour
	{
		public ResourceType type = ResourceType.Power;
		public Refinery refineryPrefab;
		private Refinery m_refineryIns = null;
		public bool CreateRefinery()
		{
			if (null == m_refineryIns && refineryPrefab!=null)
			{
				var go = Object.Instantiate
					(refineryPrefab.gameObject) as GameObject;

				m_refineryIns = go.GetComponent<Refinery> ();
			}
			return false;
		}
	}
}