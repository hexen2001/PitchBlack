using UnityEngine;
using System.Collections;

public class LightTrigger : TouchBase
{
	protected override void OnEnter(Character marine)
	{
		if( marine is Marine )
		{
			( marine as Marine ).lightCount++;
		}
	}
	protected override void OnExit(Character marine)
	{
		if( marine is Marine )
		{
			( marine as Marine ).lightCount--;
		}
	}


}
