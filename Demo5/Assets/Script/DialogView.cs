using UnityEngine;
using System.Collections;

public class DialogView : MonoBehaviour
{
	public void OnGUI()
	{
		var dialog = Manager.main.ctrlPlayer.vision.first.GetComponent<Dialog>();

		if (dialog != null)
		{
			GUILayout.BeginVertical (GUI.skin.box);

//			foreach (GameObject obj in dialogs)
			{
//				var dlg = obj.GetComponent<Dialog> ();
				if (dialog != null)
				{
					GUILayout.BeginHorizontal ();
					dialog.DrawView ();
					GUILayout.EndHorizontal ();
				}
			}

			GUILayout.EndVertical ();
		}
	}
	void OnDrawGizmos()
	{
		if (Manager.main.ctrlPlayer != null)
		{
			if (Manager.main.ctrlPlayer.vision.first != null)
			{
				var dialog = Manager.main.ctrlPlayer.vision.first.GetComponent<Dialog> ();
				if (dialog != null)
				{
					Gizmos.color = Color.cyan;
					Gizmos.DrawLine (Manager.main.ctrlPlayer.transform.position, dialog.transform.position);
				}
			}
		}
	}
}
