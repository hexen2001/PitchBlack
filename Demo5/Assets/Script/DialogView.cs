using UnityEngine;
using System.Collections;

public class DialogView : MonoBehaviour
{
	public void OnGUI()
	{
		var dialog = currentDialog;
		if (dialog != null)
		{
			GUILayout.BeginVertical (GUI.skin.box);

			if (dialog != null)
			{
				GUILayout.BeginHorizontal ();
				dialog.DrawView ();
				GUILayout.EndHorizontal ();
			}

			GUILayout.EndVertical ();
		}
	}
	private Dialog currentDialog
	{
		get{
			var player = Manager.main.ctrlPlayer;
			if (player != null && player.vision!=null&& player.vision.first!=null)
			{
				var dialog = player.vision.first.GetComponent<Dialog> ();
				return dialog;
			}
			return null;
		}
	}

	void OnDrawGizmos()
	{
		var dialog = currentDialog;
		if (dialog != null)
		{
			Gizmos.color = Color.cyan;
			Gizmos.DrawLine (Manager.main.ctrlPlayer.transform.position, dialog.transform.position);
			Gizmos.DrawWireSphere (dialog.transform.position, 2f);
		}
	}
}
