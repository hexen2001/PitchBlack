using UnityEngine;
using System.Collections;

namespace Demo4
{
	public class TouchField : Toggle
	{
		void OnTriggerEnter(Collider collider)
		{
			Raise (true);
		}
		void OnTriggerExit(Collider collider)
		{
			Raise (false);
		}
	}
}