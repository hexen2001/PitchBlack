using UnityEngine;
using System.Collections.Generic;

namespace Demo4
{
	public class Toggle : MonoBehaviour
	{
		[System.Serializable]
		public class Node
		{
			public Object target;
			public bool active;
		}

		public List<Node> nodes = new List<Node>();

		public void Raise (bool active)
		{
			foreach (var node in nodes)
			{
				bool realActive = active ? node.active : !node.active;
				if (node.target is GameObject && node.target != null )
				{
					(node.target as GameObject).SetActive (realActive );
				}
				else if (node.target is Behaviour && node.target != null )
				{
					(node.target as Behaviour).enabled = realActive;
				}
			}
		}
	}
	public class InputToggle : Toggle
	{
		public KeyCode key = KeyCode.J;

		void Update ()
		{
			if (Input.GetKeyDown (key))
			{
				Raise ( true );
			}		
		}
	}

}