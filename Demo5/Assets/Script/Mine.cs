using UnityEngine;
using System.Collections;

public class Mine : Dialog
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
	public override void DrawView ()
	{
		GUILayout.Label ( "Mine("+name+")" );

		if (!isBuilding)
		{
			if (GUILayout.Button ("Build (Space)")
				|| Input.GetKeyDown (KeyCode.Space)
			)
			{
				Build ();
			}
		}
		else
		{
			if (GUILayout.Button ("Cancel (Escape)")
				|| Input.GetKeyDown(KeyCode.Escape)
			)
			{
				m_buildingTime = -1;
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
			guiRect = TitleUtil.rect;
			TitleUtil.DrawLabel( ((int)(buildProcess*100))+"%" );
		}
	}
	private Rect guiRect;

	[SerializeField]
	private Refinery m_refineryInstance = null;
	private float m_buildingTime = -1f;
}
