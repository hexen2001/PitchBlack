using UnityEngine;
using System.Collections.Generic;


public abstract class VisionRangeBase : Vision
{

	public override GameObject first
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
	private List<GameObject> targets = new List<GameObject>();


	protected override void OnTriggerEnter(Collider collider)
	{
		targets.Add( collider.gameObject );
	}


	protected override void OnTriggerExit(Collider collider)
	{
		targets.Remove( collider.gameObject );
	}


	protected virtual void Update()
	{
		targets.RemoveAll( obj => obj == null );
	}


	protected void SortByNearToFar()
	{
		var selfPosition = Manager.main.ctrlPlayer.transform.position;
		targets.Sort( (GameObject a, GameObject b) =>
		{
			float distanceA = ( a.transform.position - selfPosition ).magnitude;
			float distanceB = ( b.transform.position - selfPosition ).magnitude;
			return distanceA < distanceB ? -1 : 1;
		} );
	}
}

public class VisionRange : VisionRangeBase
{
}
