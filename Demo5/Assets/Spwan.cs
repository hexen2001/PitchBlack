using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 刷新点
/// 按规则刷新怪物的地方
/// </summary>
public class Spwan : MonoBehaviour
{
	/// <summary>
	/// 怪物Prefab
	/// </summary>
	public GameObject prefab;
	/// <summary>
	/// 同时存在的数量限制
	/// </summary>
	public int insCountLimit = 1;
	/// <summary>
	/// 拥有物体总量
	/// </summary>
	public int totalCount = 3;
	/// <summary>
	/// 创建物体的延时
	/// </summary>
	public float createIntervals = 0f;
	/// <summary>
	/// 上一次创建物体的时间
	/// </summary>
	private float m_lastCreateTime;
	/// <summary>
	/// 启动时检查是否没有物体Prefab
	/// </summary>
	protected void Awake()
	{
		if (prefab == null)
		{
			Debug.LogError ("[Spwan]Missing Assets!", gameObject); 
		}
	}
	/// <summary>
	/// 当前实例数量
	/// </summary>
	private int insCount
	{
		get
		{
			return m_insTable.Count;
		}
	}
	/// <summary>
	/// 将实例放置入某处
	/// </summary>
	private Transform insParent
	{
		get
		{
			return transform;
		}
	}
	/// <summary>
	/// 创建一个物体
	/// </summary>
	private void CreateObject()
	{
		var go = prefab.Create (insParent);
		m_insTable.Add (go);
	}
	/// <summary>
	/// 移除已经不存在的物体
	/// </summary>
	private void UpdateClearMissingIns()
	{
		int oriCount = m_insTable.Count;
		m_insTable.Remove (null);
		bool isRemoved = oriCount > m_insTable.Count;
		if (isRemoved)
		{
			if (m_lastCreateTime < Time.time - createIntervals)
			{
				m_lastCreateTime = Time.time;
			}
		}
	}
	/// <summary>
	/// 帧逻辑
	/// </summary>
	protected void Update()
	{
		UpdateClearMissingIns ();
		while (0 < totalCount && insCount < insCountLimit
			&& m_lastCreateTime + createIntervals <= Time.time)
		{
			m_lastCreateTime = Time.time;
			--totalCount;
			CreateObject ();
		}
	}
	/// <summary>
	/// 画辅助体
	/// </summary>
	void OnDrawGizmos()
	{
		Gizmos.color = Color.green / 2;
		Gizmos.DrawWireSphere (transform.position,1f);
	}
	/// <summary>
	/// 实例列表
	/// </summary>
	private List<GameObject> m_insTable = new List<GameObject>();
}