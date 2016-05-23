using UnityEngine;
using System.Collections;

namespace Demo4
{
	public class EventInputKey : Event
	{
		public enum Mode
		{
			Key,
			KeyDown,
			KeyUp,
		}
		public Mode mode = Mode.KeyDown;
		public KeyCode key;
		protected void Update()
		{
			switch (mode)
			{
			case Mode.Key:
				if (Input.GetKey (key))
				{
					Raise ();
				}
				break;

			case Mode.KeyDown:
				if (Input.GetKeyDown (key))
				{
					Raise ();
				}
				break;

			case Mode.KeyUp:
				if (Input.GetKeyUp (key))
				{
					Raise ();
				}
				break;

			}
		}		
	}
}