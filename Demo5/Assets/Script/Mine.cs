using UnityEngine;
using System.Collections;

public class Mine : TouchBase
{
	public Refinery refineryPrefab = null;
	public float totalTime = 1f;
	[ContextMenu("Build")]
	public bool Build()
	{
		if( isCanBuild )
		{
			m_buildingTime = totalTime;
			return true;
		}
		else
		{
			return false;
		}
	}
	private bool isCanBuild
	{
		get
		{
			return refineryPrefab != null && m_refineryInstance == null && m_buildingTime <= 0f;
		}
	}
	private bool isBuilding
	{
		get
		{
			return m_refineryInstance == null && m_buildingTime > 0f;
		}
	}
	private float buildProcess
	{
		get
		{
			return Mathf.Clamp01( 1f - m_buildingTime / totalTime );
		}
	}
	private void Create()
	{
		if( refineryPrefab != null )
		{
			m_refineryInstance = refineryPrefab.gameObject.Create( transform ).GetComponent<Refinery>();
		}
	}
	protected void OnGUI()
	{
		if( isBuilding )
		{
			TitleUtil.position = transform.position;
			TitleUtil.offset = TitleUtil.Line1;
			TitleUtil.DrawLabel( "" );
		}
	}
	protected void Update()
	{
		if( isBuilding )
		{
			m_buildingTime -= Time.deltaTime;

			Debug.Log( ">" + ((int)( 100* buildProcess)).ToString() );
			if( !isBuilding )
			{
				Create();
			}
		}
	}
	[SerializeField]
	private Refinery m_refineryInstance = null;
	private float m_buildingTime = -1f;
}
