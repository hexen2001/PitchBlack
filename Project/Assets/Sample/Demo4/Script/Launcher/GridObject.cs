using UnityEngine;
using System.Collections;

namespace Demo4
{
	/// <summary>
	/// 网格对象
	/// 对齐到网格的物体
	/// 将自身加入到管理器,使之可以被检测到.
	/// </summary>
	[ExecuteInEditMode]
	public class GridObject : MonoBehaviour
	{
		protected const int GridSize = 10;

		[System.Serializable]
		public class Point
		{
			public int x, y, z;

			public void FromVector3 (Vector3 v)
			{
				x = (int)(v.x / GridSize);
				y = (int)(v.y / GridSize);
				z = (int)(v.z / GridSize);
			}

			public Vector3 ToVector3 ()
			{
				return new Vector3 (x * GridSize, y * GridSize, z * GridSize);
			}

			public static Vector3 One
			{
				get
				{
					return new Vector3 (GridSize, GridSize, GridSize);
				}
			}
		}

		/// <summary>
		/// 于网格上的位置
		/// </summary>
		public Point gridPos;

		/// <summary>
		/// 取得于网格上的绝对位置
		/// </summary>
		/// <value>The position now.</value>
		public Point gridPosNow
		{
			get
			{
				Point result = new Point ();
				result.FromVector3 (transform.position);
				return result;
			}
		}
		protected void Update()
		{
			gridPos = gridPosNow;
			transform.position = gridPos.ToVector3();
		}
		protected void Awake()
		{
			if (Application.isPlaying)
			{
				Manager.main.gridMngr.Add (this);
			}
		}
		void OnDrawGizmos()
		{
			Gizmos.color = new Color(0,0,1,0.5f);
			var pos = gridPosNow;
			Gizmos.DrawWireCube (pos.ToVector3 (), GridObject.Point.One);
		}
		protected void OnDestroy()
		{
			if (Application.isPlaying)
			{
				Manager.main.gridMngr.Remove (this);
			}
		}
	}

}