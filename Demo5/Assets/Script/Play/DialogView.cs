using UnityEngine;
using System.Collections;

public class DialogView : MonoBehaviour
{
	public Dialog current;
	public void OnGUI()
	{
		var dialog = current;
		if( dialog!=null )
		{
			GUILayout.BeginVertical( GUI.skin.box );

			if( dialog != null )
			{
				GUILayout.BeginHorizontal();
				dialog.DrawView();
				GUILayout.EndHorizontal();
			}

			GUILayout.EndVertical();
		}
	}
	protected void Update()
	{
		if (Input.GetMouseButtonDown (0))
		{
			CheckPick();
		}
	}
	void CheckPick()
	{
		var screenPos = Input.mousePosition;


		var ray = Camera.main.ScreenPointToRay (screenPos);


		RaycastHit hit;


		int hitFlag = 1 << (int)Layer.Dialog
			| 1 << (int)Layer.Terrain;


		if (Physics.Raycast (ray, out hit,1000,hitFlag))
		{
			if (hit.collider != null)
			{
				current = hit.collider.gameObject.GetComponent<Dialog> ();
			}
		}
	}
}
