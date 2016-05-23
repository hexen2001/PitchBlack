using UnityEngine;
using System.Collections.Generic;

namespace Demo4
{
	/// <summary>
	/// 施加状态的装置
	/// 进入范围将申请获得某状态
	/// 离开后将申请移除某状态
	/// </summary>
	public class BuffCaster : MonoBehaviour
	{

		/// <summary>
		/// 状态物体的Prefab
		/// </summary>
		public Buff prefab = null;

		/// <summary>
		/// 增加状态
		/// </summary>
		/// <param name="collider"></param>
		void OnTriggerEnter(Collider collider)
		{
			if( enabled )
			{
				var target = collider.gameObject.GetComponent<BuffList>();
				if( target != null )
				{
					target.AddBuff( prefab );
				}
			}
		}

		/// <summary>
		/// 减少状态
		/// </summary>
		/// <param name="collider"></param>
		void OnTriggerExit(Collider collider)
		{
			if( enabled )
			{
				var target = collider.gameObject.GetComponent<BuffList>();
				if( target != null )
				{
					target.RemoveBuff( prefab );
				}
			}
		}
	}
}
