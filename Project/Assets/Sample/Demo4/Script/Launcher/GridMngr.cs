using UnityEngine;
using System.Collections.Generic;

namespace Demo4
{
	/// <summary>
	/// 网格管理器
	/// 用于检索某个位置是否有网格物体
	/// </summary>
	public class GridMngr : MonoBehaviour
	{
		public void Add(GridObject obj)
		{
			objects.Add (obj);
		}
		public void Remove(GridObject obj)
		{
			objects.Remove (obj);
		}
		public GridObject Get(int x, int y )
		{
			return objects.Find((GridObject obj)=>{
				return obj.gridPosNow.x == x
					&& obj.gridPosNow.y == y;
			} );
		}
		public List<GridObject> objects
			= new List<GridObject>();
	}
}