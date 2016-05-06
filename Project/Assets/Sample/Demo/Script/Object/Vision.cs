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

public abstract class VisionBase : MonoBehaviour
{
	public abstract GameObject first
	{
		get;
	}
	public abstract bool Empty
	{
		get;
	}
	public abstract List<GameObject> target
	{
		get;
	}
}

[RequireComponent(typeof(Rigidbody))]
public class Vision : VisionBase
{
	public float radius = 10f;
	public override GameObject first
	{
		get{
			if (target.Count > 0)
			{
				return target [0];
			}
			return null;
		}
	}
	public override bool Empty
	{
		get{
			return target.Count == 0;
		}
	}
	public override List<GameObject> target
	{
		get
		{
			return m_target;
		}
	}
	private List<GameObject> m_target = new List<GameObject>();
	protected void Awake()
	{
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

	void DrawEnemyLine ()
	{
		if (target != null)
		{
			Gizmos.color = Color.gray;
			var center = transform.position;
			foreach (var obj in target)
			{
				Gizmos.DrawLine (center, obj.transform.position);
			}
		}
	}

	void DrawVisionRange ()
	{
		Gizmos.color = new Color (0, 0, 1, 0.25f);
		Gizmos.matrix = transform.localToWorldMatrix;
		Gizmos.DrawWireSphere (Vector3.zero, radius);
		Gizmos.color = Color.red;
		Gizmos.DrawLine (Vector3.zero, Vector3.forward * radius);
	}

	void OnDrawGizmos()
	{
		DrawEnemyLine ();
		DrawVisionRange ();




	}
}
