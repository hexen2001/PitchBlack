using UnityEngine;
using System.Collections.Generic;


public abstract class VisionRangeBase<T> : Vision
	where T : Component
{

	public override Object first
	{
		get
		{
			if( targets.Count > 0 )
			{
				return targets[ 0 ];
			}
			return null;
		}
	}


	[SerializeField]
	private List<T> targets = new List<T>();


	protected override void OnTriggerEnter(Collider collider)
	{
		var target = collider.gameObject.GetComponent<T>();
		if( target != null )
		{
			targets.Add( target );
		}
	}


	protected override void OnTriggerExit(Collider collider)
	{
		var target = collider.gameObject.GetComponent<T>();
		if( target != null )
		{
			targets.Remove( target );
		}
	}


	protected virtual void Update()
	{
		targets.RemoveAll( obj => obj == null );
	}


	protected void SortByNearToFar()
	{
		var selfPosition = Manager.main.ctrlPlayer.transform.position;
		targets.Sort( (T a, T b) =>
		{
			float distanceA = ( a.transform.position - selfPosition ).magnitude;
			float distanceB = ( b.transform.position - selfPosition ).magnitude;
			return distanceA < distanceB ? -1 : 1;
		} );
	}
}

public class VisionRange : VisionRangeBase<Character>
{
}
