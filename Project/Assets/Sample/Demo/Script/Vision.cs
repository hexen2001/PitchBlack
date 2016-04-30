using UnityEngine;
using System.Collections.Generic;

static class ExtendGameObjectGetOrAddComponent
{
	public static T GetOrAddComponent<T>(this GameObject self)
		where T : Component
	{
		var result = self.GetComponent<T> ();
		if (result == null)
		{
			result = self.AddComponent<T> ();
		}
		return result;
	}
}

[RequireComponent(typeof(Rigidbody))]
public class Vision : MonoBehaviour
{
	public float radius = 10f;
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
	public List<GameObject> target
	{
		get;
		private set;
	}
	protected void Awake()
	{
		target = new List<GameObject> ();
		gameObject.GetOrAddComponent<SphereCollider> ().radius = radius;
	}
	protected void OnTriggerEnter(Collider collider)
	{
		target.Add (collider.gameObject);
		target.RemoveAll (obj => obj == null);
	}
	protected void OnTriggerExit(Collider collider)
	{
		target.Remove (collider.gameObject);
	}
	void OnDrawGizmos()
	{
		Gizmos.color = new Color(0,0,1, 0.25f);
		Gizmos.matrix = transform.localToWorldMatrix;
		Gizmos.DrawWireSphere (Vector3.zero, radius );
		Gizmos.color = Color.red;
		Gizmos.DrawLine (Vector3.zero, Vector3.forward * radius);
	}
}
