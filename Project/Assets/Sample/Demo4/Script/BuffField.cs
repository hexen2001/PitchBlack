﻿using UnityEngine;
using System.Collections.Generic;

namespace Demo4
{
	public class BuffField : MonoBehaviour
	{
		public List<Character> targetList = new List<Character> ();
		void OnTriggerEnter(Collider collider)
		{
			var target = collider.gameObject.GetComponent<Character> ();
			if (target != null)
			{
				targetList.Add (target);
				OnCharacterIn (target);
			}
		}
		void OnTriggerExit(Collider collider)
		{
			var target = collider.gameObject.GetComponent<Character> ();
			if (target != null)
			{
				OnCharacterOut (target);
				targetList.Remove (target);
			}
		}
		protected virtual void OnCharacterIn(Character target)
		{
		}
		protected virtual void OnCharacterOut(Character target)
		{
		}
		protected virtual void Update()
		{
		}
	}
}
