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
			if( m_targets.Count > 0 )
			{
				return m_targets[ 0 ];
			}
			return null;
		}
	}



	public override List<GameObject> targets
	{
		get
		{
			return m_targets;
		}
	}



	[SerializeField]
	private List<GameObject> m_targets = new List<GameObject>();


	protected override void OnTriggerEnter(Collider collider)
	{
		m_targets.Add( collider.gameObject );
	}


	protected override void OnTriggerExit(Collider collider)
	{
		m_targets.Remove( collider.gameObject );
	}


	protected virtual void Update()
	{
		m_targets.RemoveAll( obj => obj == null );
		if (sortMode == SortMode.NearToFar)
		{
			SortByNearToFar ();
		}
	}


	protected void SortByNearToFar()
	{
		var selfPosition = transform.position;
		m_targets.Sort( (GameObject a, GameObject b) =>
		{
			float distanceA = ( a.transform.position - selfPosition ).magnitude;
			float distanceB = ( b.transform.position - selfPosition ).magnitude;
			return distanceA < distanceB ? -1 : 1;
		} );
	}
}

