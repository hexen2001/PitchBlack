using UnityEngine;
using System.Collections;

namespace Demo4
{
	public abstract class Condition : MonoBehaviour
	{
		public bool not = false;
		public bool Check()
		{
			return OnCheck ()!= not;
		}
		protected abstract bool OnCheck ();
	}
}