using UnityEngine;
using System.Collections.Generic;


public class VisionRange : Vision
{

	public enum SortMode
	{
		None,
		NearToFar,
	}
	public SortMode sortMode = SortMode.NearToFar;
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
		if (sortMode == SortMode.NearToFar)
		{
			SortByNearToFar ();
		}
	}


	protected void SortByNearToFar()
	{
		var selfPosition = transform.position;
		targets.Sort( (GameObject a, GameObject b) =>
		{
			float distanceA = ( a.transform.position - selfPosition ).magnitude;
			float distanceB = ( b.transform.position - selfPosition ).magnitude;
			return distanceA < distanceB ? -1 : 1;
		} );
	}
}

