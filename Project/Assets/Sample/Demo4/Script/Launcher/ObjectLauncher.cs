using UnityEngine;
using System.Collections;


namespace Demo4
{
	/// <summary>
	/// 物体加载器
	/// 基于网格加载物体
	/// 加载完就释放自身
	/// </summary>
	[ExecuteInEditMode]
	public class ObjectLauncher : GridObject
	{
		/// <summary>
		/// 物体Prefab
		/// </summary>
		public GameObject prefab;
		/// <summary>
		/// 加载的等候时间
		/// </summary>
		public float lanucherTime;
		public Title title;
		/// <summary>
		/// 加载过程
		/// </summary>
		private IEnumerator Start()
		{
			//	等候,并更新显示.
			float endTime = Time.time + lanucherTime;
			while( Time.time < endTime )
			{
				float scale = (endTime - Time.time) / lanucherTime;
				title.text = (int)( scale * 100 ) + "%";
				yield return new WaitForEndOfFrame ();
			}
			title.text = "";

			//	创建至同层,并移除自己.
			var go = prefab.Create( transform );
			go.transform.parent = transform.parent;

			Object.Destroy( gameObject );

		}
	}
}