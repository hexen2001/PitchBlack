using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Demo4
{
	public class Building : MonoBehaviour
	{
		/// <summary>
		/// 实例引用
		/// </summary>
		public GameObject buildingInstance = null;

		/// <summary>
		/// 构造清单
		/// </summary>
		public BuildingList makeList;

		/// <summary>
		/// 状态
		/// </summary>
		public enum State
		{
			//	空地,什么也没有
			Empty,

			//	装载中
			Launcher,

			//	正在运行中
			Running,
		}
		public State state;
		public Title title;
		/// <summary>
		/// 按指定Info造物
		/// </summary>
		public void Create(BuildingList.MakeInfo makeInfo)
		{
			if (state == State.Empty)
			{
				state = State.Launcher;
				StartCoroutine (CreateTask(makeInfo));
			}
		}
		private IEnumerator CreateTask(BuildingList.MakeInfo makeInfo)
		{
			//	
			float endTime = Time.time + makeInfo.time;
			while( Time.time < endTime )
			{
				float scale = (endTime - Time.time) / makeInfo.time;
				title.text = (int)( scale * 100 ) + "%";
				yield return new WaitForEndOfFrame ();
			}
			buildingInstance = makeInfo.prefab.Create (transform);
			state = State.Running;
			while(buildingInstance!=null)
			{
				yield return new WaitForSeconds (1f);
			}
			state = State.Empty;
		}

		#region 应答机制
		void OnTriggerEnter(Collider collider)
		{
			if ( CheckIsMarine (collider))
			{
				dialogBuildingList.Add (this);
			}
		}
		void OnTriggerExit(Collider collider)
		{
			if ( CheckIsMarine (collider))
			{
				dialogBuildingList.Add (this);
			}
		}
		private static List<Building> dialogBuildingList
		= new List<Building> ();
		private bool CheckIsMarine(bool collider)
		{
			return false;
		}
		#endregion

		#region Debug
		public List<Building> debugShowDialogList;
		protected void Update()
		{
			debugShowDialogList = dialogBuildingList;
		}
		#endregion

	}
}