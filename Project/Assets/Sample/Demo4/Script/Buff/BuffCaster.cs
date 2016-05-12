using UnityEngine;
using System.Collections.Generic;

namespace Demo4
{
	//	施加状态的装置
	//	进入范围将申请获得某状态
	//	离开后将申请移除某状态
	public class BuffCaster : MonoBehaviour
	{
		public Buff prefab = null;
		void OnTriggerEnter(Collider collider)
		{
			if (enabled)
			{
				var target = collider.gameObject.GetComponent<BuffList> ();
				if (target != null)
				{
					target.AddBuff (prefab);
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
					target.RemoveBuff (prefab);
				}
			}
		}
	}
}
