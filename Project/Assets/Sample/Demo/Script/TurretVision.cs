using UnityEngine;
using System.Collections.Generic;

public class TurretVision : MonoBehaviour
{
	public GameObject first
	{
		get{
			if (target.Count > 0)
			{
				return target [0];
			}
			return null;
		}
	}
	public bool Empty
	{
		get{
			return target.Count == 0;
		}
	}
	public List<GameObject> target = new List<GameObject>();
	void OnTriggerEnter(Collider collider)
	{
		target.Add (collider.gameObject);
	}
	void OnTriggerExit(Collider collider)
	{
		target.Remove (collider.gameObject);
	}
	private SphereCollider m_sphereCollider;
	private SphereCollider sphereCollider
	{
		get
		{
			if (null == m_sphereCollider)
			{
				m_sphereCollider = GetComponent<SphereCollider> ();
			}
			return m_sphereCollider;
		}
	}
	void OnDrawGizmos()
	{
		Gizmos.color = new Color(0,0,1, 0.25f);
		Gizmos.matrix = transform.localToWorldMatrix;
		Gizmos.DrawWireSphere (Vector3.zero, sphereCollider.radius);
		Gizmos.color = Color.red;
		Gizmos.DrawLine (Vector3.zero, Vector3.forward * sphereCollider.radius);
	}
}
