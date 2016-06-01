using UnityEngine;
using System.Collections;

public class Mine : Dialog
{
	public GameObject prefab = null;
	public float totalTime = 3f;
	public KeyCode buildHotKey = KeyCode.Space;

	[ContextMenu( "Build" )]
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
	public void Stop()
	{
		m_buildingTime = -1;
	}
	private bool isCanBuild
	{
		get
		{
			return prefab != null && m_instance == null && m_buildingTime <= 0f;
		}
	}
	private bool isBuilding
	{
		get
		{
			return m_instance == null && m_buildingTime > 0f;
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
		if( prefab != null )
		{
			m_instance = prefab.Create( transform );
		}
	}
	protected void Update()
	{
		if( isBuilding )
		{
			m_buildingTime -= Time.deltaTime;

			if( !isBuilding )
			{
				Create();
			}
		}
	}
	protected void OnGUI()
	{
		if( isBuilding )
		{
			TitleUtil.textColor = Color.blue;
			TitleUtil.position = transform.position;
			TitleUtil.offset = TitleUtil.Line1;
			TitleUtil.DrawLabel( ( (int)( buildProcess * 100 ) ) + "%" );
		}
	}
	public override void Draw()
	{
		if (m_instance == null)
		{
			GUILayout.Label ("Mine(" + name + ")");
		}

		if( isCanBuild )
		{
			if( GUILayout.Button( "Build (" + buildHotKey.ToString() + ")" )
				|| Input.GetKeyDown( buildHotKey )
			)
			{
				Build();
			}
		}
		else if( isBuilding )
		{
			if( GUILayout.Button( "Cancel (Escape)" )
				|| Input.GetKeyDown( KeyCode.Escape )
			)
			{
				Stop();
			}
		}
	}

	[SerializeField]
	private GameObject m_instance = null;
	private float m_buildingTime = -1f;
}
