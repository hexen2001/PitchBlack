using UnityEngine;
using System.Collections;

public enum Layer
{
	Force1 = 8,
	Force1Fire = 12,
	Force2 = 9,
	Force2Fire = 13,
}
public enum Camp
{
	Human,
	Monster,
}
public abstract class Character : MonoBehaviour
{
	public Vision vision
	{
		get;
		private set;
	}
	[SerializeField]
	private Camp camp = Camp.Human;
	public Layer layer
	{
		get;
		private set;
	}
	private Gun gun = null;
	public bool Fire()
	{
		if (null == gun)
		{
			return false;
		}
		if (gun.IsCooldown)
		{
			return false;
		}
		var go = gun.Fire ();
		if (go != null)
		{
			go.layer = (int)fireLayer;
		}
		return true;
	}
	public Layer fireLayer
	{
		get;
		private set;
	}
	protected void UpdateLayer ()
	{
		switch (camp)
		{
		case Camp.Human:
			layer = Layer.Force1;
			fireLayer = Layer.Force1Fire;
			gameObject.layer = (int)layer;
			break;
		case Camp.Monster:
		default:
			layer = Layer.Force2;
			fireLayer = Layer.Force2Fire;
			gameObject.layer = (int)layer;
			break;
		}
	}
	public GameObject target
	{
		get
		{
			return vision.first;
		}
	}
	protected virtual void Awake()
	{
		UpdateLayer ();
		vision = GetComponentInChildren<Vision> ();
		gun = GetComponentInChildren<Gun> ();
	}
}

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
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.matrix = transform.localToWorldMatrix;
		Gizmos.DrawWireSphere (Vector3.zero, 1f);
	}
}
