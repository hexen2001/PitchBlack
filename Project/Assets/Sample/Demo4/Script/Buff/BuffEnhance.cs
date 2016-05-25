using UnityEngine;
using System.Collections;

namespace Demo4
{
	public class BuffEnhance : BuffInc
	{
		void Start()
		{
			Add( amount );
		}
		void OnDisable()
		{
			Add( amount.ToInverse() );
		}

	}
}