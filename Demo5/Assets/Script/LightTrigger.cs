using UnityEngine;
using System.Collections;

public class LightTrigger : TouchBase
{
	protected override void OnTriggerEnter(Collider target)
	{
		var marine = target.GetComponent<Marine>();
		if( marine != null )
		{
			marine.lightCount++;
		}
	}
	protected override void OnTriggerExit(Collider target)
	{
		var marine = target.GetComponent<Marine>();
		if( marine != null )
		{
			marine.lightCount--;
		}
	}


}
