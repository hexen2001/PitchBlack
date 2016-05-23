using UnityEngine;
using System.Collections;

namespace Demo4
{
	/// <summary>
	/// 网格对象
	/// 对齐到网格的物体
	/// 将自身加入到管理器,使之可以被检测到.
	/// </summary>
	public class GridObject : MonoBehaviour
	{
		#region 自动更新位置
		public class Point
		{
			public int x, y, z;

			public void FromVector3(Vector3 v)
			{
				x = (int)( ( v.x / GridSize ) + 0.5f );
				y = (int)( ( v.y / GridSize ) + 0.5f );
				z = (int)( ( v.z / GridSize ) + 0.5f );
			}

			public Vector3 ToVector3()
			{
				return new Vector3( x * GridSize, y * GridSize, z * GridSize );
			}

			public static Vector3 One
			{
				get
				{
					return new Vector3( GridSize, GridSize, GridSize );
				}
			}
		}
		/// <summary>
		/// 更新模式
		/// </summary>
		public enum GridUpdateMode
		{
			//	不更
			None,
			//	启动时更新一次
			Start,
			//	一直更新
			Update,
		};
		/// <summary>
		/// 更新模式
		/// </summary>
		public GridUpdateMode gridUpdateMode = GridUpdateMode.Start;
		/// <summary>
		/// 格子尺寸
		/// </summary>
		private const int GridSize = 4;
		/// <summary>
		/// 启动时处理更新位置
		/// </summary>
		protected virtual IEnumerator Start()
		{
			switch( gridUpdateMode )
			{
				case GridUpdateMode.Start:
					NormalizePosition();
					break;
				case GridUpdateMode.Update:
					for( ; ; )
					{
						NormalizePosition();
						yield return new WaitForEndOfFrame();
					}
				case GridUpdateMode.None:
				default:
					break;
			}
		}
		protected virtual void Update()
		{
			switch( gridUpdateMode )
			{
				case GridUpdateMode.Update:
					{
						NormalizePosition();
						break;
					}
				case GridUpdateMode.None:
				default:
					break;
			}
		}
		/// <summary>
		/// 取得于网格上的绝对位置
		/// </summary>
		/// <value>The position now.</value>
		public Point gridPosNow
		{
			get
			{
				Point result = new Point();
				result.FromVector3( transform.position );
				return result;
			}
		}
		/// <summary>
		/// 位置规则化
		/// </summary>
		public void NormalizePosition()
		{
			transform.position = gridPosNow.ToVector3();
		}
		#endregion


		#region 注册到管理器相关
		protected void Awake()
		{
			if( Manager.main != null )
			{
				Manager.main.gridMngr.Add( this );
			}
		}
		protected void OnDestroy()
		{
			if( Manager.main != null )
			{
				Manager.main.gridMngr.Remove( this );
			}
		}
		#endregion


		#region 画Gizmos
		protected void OnDrawGizmos()
		{
			Gizmos.color = new Color( 0, 0, 1, 0.5f );
			var pos = gridPosNow;
			Gizmos.DrawWireCube( pos.ToVector3(), GridObject.Point.One );
		}
		#endregion
	}

}