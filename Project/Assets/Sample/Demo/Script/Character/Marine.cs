using UnityEngine;
using System.Collections;


public abstract class Runner : Character
{
	public NavMeshAgent nav;
	public void SetDest(Vector3 dest)
	{
		nav.SetDestination (dest);
	}
	public bool m_isMoving;
	public bool isMoving
	{
		get
		{
			return m_isMoving;
		}
	}
}

public class Marine : Runner
{
	protected override void OnDrawGizmos()
	{
		base.OnDrawGizmos ();

		Gizmos.color = Color.blue;
		Gizmos.matrix = transform.localToWorldMatrix;
		Gizmos.DrawWireSphere (Vector3.zero, 1f);
	}
}
