using UnityEngine;
using System.Collections;

namespace Demo4
{
	public class BuffEnhance : BuffAdd
	{
		void Awake()
		{
			Add( amount );
		}
		void OnDestroy()
		{
			Add( amount.ToInverse() );
		}

	}
}