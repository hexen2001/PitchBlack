using UnityEngine;
using System.Collections;

/// <summary>
/// 对话接口
/// * 提供绘制整个对话的接口
/// * 提供一种规格化的视图数据，每个数据表示一种操作。
/// * 使用者可以通过填充数据的方式实现统一风格的操作响应。
/// 
/// </summary>
public class Dialog : MonoBehaviour
{
	public virtual void Draw()
	{
		GUILayout.BeginHorizontal( GUI.skin.box );
		foreach( var item in items )
		{
			item.Draw();
		}
		GUILayout.EndHorizontal();
	}

	DialogItem[] items;
	void Awake()
	{
		items = GetComponents<DialogItem>();
	}
}
