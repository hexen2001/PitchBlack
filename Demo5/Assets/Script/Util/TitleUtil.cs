﻿using UnityEngine;
using System.Collections;


public static class TitleUtil
{
	public static GUIStyle labelStyle = GUI.skin.label;
	public static Vector3 position = Vector3.zero;

	public static Rect Line1
	{
		get
		{
			return new Rect (-25, -50, 100, 20);
		}
	}

	public static Rect Line2
	{
		get
		{
			return new Rect (-25, -30, 100, 20);
		}
	}

	public static Rect Line3
	{
		get
		{
			return new Rect (-25, -10, 100, 20);
		}
	}

	public static Color textColor
	{
		get
		{
			return TitleUtil.labelStyle.normal.textColor;
		}
		set
		{
			TitleUtil.labelStyle.normal.textColor = value;
		}
	}

	public static Rect offset = Line1;

	public static Rect rect
	{
		get{
			Rect pos = new Rect ();
			var screenPos = Camera.main.WorldToScreenPoint (position);
			screenPos.y = Screen.height - screenPos.y;
			pos.x = screenPos.x + offset.x;
			pos.y = screenPos.y + offset.y;
			pos.width = offset.width;
			pos.height = offset.height;
			return pos;
		}
	}

	public static void DrawLabel (string text)
	{
		GUI.Label (rect, text, labelStyle);
	}
}