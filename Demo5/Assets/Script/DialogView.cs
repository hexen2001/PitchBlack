using UnityEngine;
using System.Collections;

public class DialogView : MonoBehaviour
{
	public void OnGUI()
	{
		GUILayout.BeginVertical (GUI.skin.box);

		foreach( GameObject obj in Manager.main.ctrlPlayer.vision.targets )
		{
			var dlg = obj.GetComponent<Dialog> ();
			if (dlg != null)
			{
				dlg.DrawView ();
			}
		}

		GUILayout.EndVertical ();
	}
}
