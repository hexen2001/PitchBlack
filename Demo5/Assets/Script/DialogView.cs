using UnityEngine;
using System.Collections;

public class DialogView : MonoBehaviour
{
	public void OnGUI()
	{
		var dialogs = currentDialogs;
		if( dialogs != null )
		{
			foreach( var dialog in dialogs )
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
	}
	private Dialog[] currentDialogs
	{
		get
		{
			var player = Manager.main.ctrlPlayer;
			if( player != null && player.vision != null && player.vision.first != null )
			{
				var dialogs = player.vision.first.GetComponents<Dialog>();
				return dialogs;
			}
			return null;
		}
	}

	void OnDrawGizmos()
	{
		var dialogs = currentDialogs;
		if( dialogs != null && dialogs.Length > 0 )
		{
			var dialog = currentDialogs[ 0 ];
			Gizmos.color = Color.cyan;
			Gizmos.DrawLine( Manager.main.ctrlPlayer.transform.position, dialog.transform.position );
			Gizmos.DrawWireSphere( dialog.transform.position, 2f );
		}
	}
}
