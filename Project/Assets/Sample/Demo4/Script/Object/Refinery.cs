using UnityEngine;
using System.Collections;

namespace Demo4
{
	public enum ResType
	{
		Power,
		Metal,
	}
	/// <summary>
	/// 精炼厂对象
	/// 周期性给玩家添加资源的装置
	/// </summary>
	public class Refinery : MonoBehaviour
	{
		/// <summary>
		/// 资源类型和数量
		/// </summary>
		public PayPair addRes = new PayPair( ResType.Power, 1 );

		/// <summary>
		/// 隔多久加一次资源
		/// </summary>
		public float addResIntervals = 1f;

		#region 加入refinery管理
		protected void Awake()
		{
			Game.AddRefinery( this );
		}
		protected void OnDestroy()
		{
			Game.RemoveRefinery( this );
		}
		#endregion

		#region 加资源逻辑
		private void AddRes()
		{
			Manager.main.game.Add( addRes );
		}
		protected IEnumerator Start()
		{
			for( ; ; )
			{
				AddRes();
				yield return new WaitForSeconds( addResIntervals );
			}
		}
		#endregion
	}
}