using UnityEngine;
using System.Collections;

namespace Demo4
{
	public class Title : MonoBehaviour
	{
		public Rect offset = new Rect (0, 0, 100, 20);
		public string text = "<Title>";
		public Style style;
		void OnGUI()
		{
			Rect pos = new Rect();
			var screenPos = Camera.main.WorldToScreenPoint(transform.position);
			screenPos.y = Screen.height - screenPos.y;
			pos.x = screenPos.x + offset.x;
			pos.y = screenPos.y + offset.y;
			pos.width = offset.width;
			pos.height = offset.height;
			if (style != null) {
				GUI.Label (pos, text, style.style);
			} else {
				GUI.Label (pos, text);
			}
		}
	}
}