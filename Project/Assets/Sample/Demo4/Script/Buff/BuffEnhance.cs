using UnityEngine;
using System.Collections;

namespace Demo4
{
	public class BuffEnhance : BuffAdd
	{
		void Start()
		{
			Add( amount );
		}
		void OnDestroy()
		{
			Add( amount.ToInverse() );
		}

	}
}