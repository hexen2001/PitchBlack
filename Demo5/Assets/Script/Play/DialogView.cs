using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// 
/// 这个模块解决以下问题
/// * ~~当没有选中目标时，点Dialog将选中Dialog。~~
/// * ~~有选中Dialog时，画Dialog。~~
/// * ~~没有选中Dialog时，画GlobalDialog。~~
/// * ~~当有选中目标时，点空地或其它目标取消选中。~~
/// * ~~当没有选中目标时，点空地将主角移动至此。~~
/// * 当选中GlobalDialog某项时，点有光空地将造GlobalDialog选中项。
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// </summary>
public class DialogView : MonoBehaviour
{
	[SerializeField]
	private Dialog m_globalDialog = null;

	[SerializeField]
	private GameObject m_dragPreab = null;

	[SerializeField]
	private GameObject m_dragInstance = null;

	[SerializeField]
	private Dialog m_selectDialog = null;

	private bool UpdateDrag()
	{
		if( !isDrag )
		{
			return false;
		}

		if( IsCancel )
		{
			DragCancel();
		}
		else
		{
			if( m_dragInstance == null )
			{
				m_dragInstance = m_dragPreab.Create( transform );
			}
			else
			{
				UpdateDragMove();

				if( IsClick() )
				{
					UpdateDragOver();
				}
			}
		}

		return true;
	}
	private void UpdateDragMove()
	{
		RaycastHit hit;
		if( m_dragInstance != null && PickObject( out hit ) )
		{
			m_dragInstance.transform.position = hit.point;
		}
	}
	private void UpdateDragOver()
	{
		if( m_dragPreab != null )
		{
			if( m_dragInstance != null )
			{
				m_dragInstance.transform.position
					= new GridPoint( m_dragInstance.transform.position ).ToVector3();

				m_dragInstance.SendMessage( "Startup",
					SendMessageOptions.DontRequireReceiver );
				m_dragInstance = null;
			}
			m_dragPreab = null;

		}
	}
	private bool isDrag
	{
		get
		{
			return m_dragPreab != null;
		}
	}
	private void DragCancel()
	{
		m_dragPreab = null;
		if( m_dragInstance != null )
		{
			m_dragInstance.Destroy();
			m_dragInstance = null;
		}
	}
	protected void OnGUI()
	{
		var dlg = m_selectDialog;
		if( dlg == null )
		{
			dlg = m_globalDialog;
		}

		if( dlg != null )
		{
			GUILayout.BeginVertical( GUI.skin.box );

			if( dlg != null )
			{
				GUILayout.BeginHorizontal();
				dlg.Draw();
				GUILayout.EndHorizontal();
			}

			GUILayout.EndVertical();
		}
	}
	protected void Update()
	{
		if( UpdateDrag() )
		{
		}
		else if( IsClick() )
		{
			OnClick();
		}
	}
	private static bool IsCancel
	{
		get
		{
			return Input.GetKeyDown( KeyCode.Escape );
		}
	}
	private static bool IsClick()
	{
		return Input.GetMouseButtonDown( 0 );
	}
	private void OnClick()
	{
		RaycastHit hit;
		if( PickObject( out hit ) )
		{
			var dlg = hit.collider.gameObject.GetComponent<Dialog>();

			if( m_selectDialog == null && dlg == null )
			{
				Debug.Log( "move" );
				Manager.main.ctrlPlayer.nav.SetDestination( hit.point );
			}
			else if( m_selectDialog != null && dlg!= null )
			{
				m_selectDialog = null;
			}
			else
			{
				m_selectDialog = dlg;
			}
		}
	}
	private bool PickObject(out RaycastHit hit)
	{
		var screenPos = Input.mousePosition;


		var ray = Camera.main.ScreenPointToRay( screenPos );



		int hitFlag = 1 << (int)Layer.Dialog
					  | 1 << (int)Layer.Terrain;


		if( Physics.Raycast( ray, out hit, 1000, hitFlag ) )
		{
			return true;
		}
		return false;
	}
}
