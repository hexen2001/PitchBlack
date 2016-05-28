using UnityEngine;
using System.Collections;

public class LightTrigger : TouchBase
{
	protected override void OnTriggerEnter(Collider target)
	{
		var obj = target.GetComponent<Character>();
		if( obj != null )
		{
			obj.AddLight (gameObject);
		}
	}
	protected override void OnTriggerExit(Collider target)
	{
		var obj = target.GetComponent<Character>();
		if( obj != null )
		{
			obj.RemoveLight (gameObject);
		}
	}


}
