using UnityEngine;
using System.Collections.Generic;

namespace Demo4
{
	public class BuffCaster : MonoBehaviour
	{
		public Buff prefab = null;
		void Start()
		{
		}
		void OnTriggerEnter(Collider collider)
		{
			if (enabled)
			{
				var target = collider.gameObject.GetComponent<BuffList> ();
				if (target != null)
				{
					target.AddBuff (prefab);
					OnCharacterIn (target);
				}
			}
		}
		void OnTriggerExit(Collider collider)
		{
			if (enabled)
			{
				var target = collider.gameObject.GetComponent<BuffList> ();
				if (target != null)
				{
					OnCharacterOut (target);
					target.RemoveBuff (prefab);
				}
			}
		}
		protected virtual void OnCharacterIn(BuffList target)
		{
		}
		protected virtual void OnCharacterOut(BuffList target)
		{
		}
	}
}
