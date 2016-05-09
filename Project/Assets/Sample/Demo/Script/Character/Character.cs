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
	public float bodySize = 1f;
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


		Manager.main.objMngr.AddObj(this);
	}
	protected virtual void OnDestroy()
	{
		if (Manager.main != null)
		{
			Manager.main.objMngr.RemoveObj (this);
		}
	}
	protected virtual void OnDrawGizmos()
	{
		Gizmos.matrix = transform.localToWorldMatrix;
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere ( Vector3.zero, bodySize /2);
	}
}
