using UnityEngine;
using System.Collections.Generic;

namespace Demo4
{
	public class Vision : MonoBehaviour
	{
		public GameObject target
		{
			get{
				if (0 < targets.Count)
				{
					return targets [0];
				}
				return null;
			}
		}
		public List<GameObject> targets = new List<GameObject>();
		protected void OnTriggerEnter(Collider collider)
		{
			targets.Add (collider.gameObject);
		}
		protected void OnTriggerExit(Collider collider)
		{
			targets.Remove (collider.gameObject);
		}
	}
}
