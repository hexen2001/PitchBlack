using UnityEngine;
using System.Collections;

public class MoveFrom : MonoBehaviour
{
	public Vector3 offset = Vector3.up;
	public float time = 1f;
	public float delay = 0f;

	// Use this for initialization
	protected IEnumerator Start()
	{
		yield return new WaitForSeconds( delay );
		iTween.MoveFrom( gameObject, startWorldPosition, time );
	}
	private Vector3 startWorldPosition
	{
		get
		{
			return transform.localToWorldMatrix.MultiplyPoint( offset );
		}
	}
	protected void OnDrawGizmos()
	{
		Gizmos.matrix = transform.localToWorldMatrix;
		Gizmos.color = new Color( 0, 1, 0, 0.3f );
		Gizmos.DrawWireSphere( offset, 0.5f );
		Gizmos.DrawLine( offset, Vector3.zero );
	}
}
