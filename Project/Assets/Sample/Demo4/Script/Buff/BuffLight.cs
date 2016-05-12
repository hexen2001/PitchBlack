using UnityEngine;
using System.Collections;

namespace Demo4
{
	public class BuffLight : Buff
	{
		public override BuffType type
		{
			get
			{
				return BuffType.Light;
			}
		}
	}
}