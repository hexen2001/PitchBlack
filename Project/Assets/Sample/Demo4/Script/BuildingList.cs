using UnityEngine;
using System.Collections;

namespace Demo4
{
	/// <summary>
	/// 建筑列表
	/// </summary>
	public class BuildingList : MonoBehaviour
	{
		/// <summary>
		/// 建造数据
		/// 每个代表一项可召唤物
		/// </summary>
		[System.Serializable]
		public class MakeInfo
		{
			public GameObject prefab = null;
			public float time = 1.5f;
			public int priceMetal = 0;
			public int pricePower = 0;
		}

		/// <summary>
		/// 可造物清单
		/// </summary>
		public MakeInfo[] nodes;

	}
}