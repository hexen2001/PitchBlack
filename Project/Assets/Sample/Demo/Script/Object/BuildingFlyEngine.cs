using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class BuildingFlyEngine : MonoBehaviour
{
	public bool fly = false;
	private bool m_finishFly = false;
	public bool isDone
	{
		get{
			return fly == m_finishFly;
		}
	}
	public float speed=0.1f;
	public float flyHeight = 5f;
	public float landHeight
	{
		get;
		private set;
	}
	protected void Awake()
	{
		landHeight = 0f;
	}
	private bool m_isRun = false;
	protected void Update()
	{
		if (m_finishFly != fly)
		{
			m_isRun = true;
		}

		if (m_isRun )
		{			
			var pos = transform.localPosition;
			var epos = new Vector3 (pos.x, fly ? flyHeight : landHeight, pos.z);
			if (Mathf.Abs (epos.y - pos.y) < 0.1f || !Application.isPlaying)
			{
				transform.localPosition = epos;
				m_finishFly = fly;
				m_isRun = false;
			}
			else
			{
				transform.localPosition = Vector3.Lerp (pos, epos, speed);
			}
		}
	}
}
