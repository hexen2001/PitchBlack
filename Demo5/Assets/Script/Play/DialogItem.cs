using UnityEngine;
using System.Collections;

/// <summary>
/// 对话条目
/// 
/// </summary>
public class DialogItem : MonoBehaviour
{
	public virtual void Draw()
	{
		GUILayout.Button( "Click", GUILayout.Width( 40 ), GUILayout.Height( 40 ) );
	}
}
