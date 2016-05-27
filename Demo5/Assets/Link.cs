using UnityEngine;
using System.Collections;


public class Link : MonoBehaviour
{
	public enum Mode
	{
		Manual,
		LoadOnAwake,
	}

	public Mode mode = Mode.LoadOnAwake;
	
	public GameObject prefab = null;

	public float delay = 0f;

	public GameObject instance
	{
		get
		{
			return m_ins;
		}
	}

	public bool isLoaded
	{
		get
		{
			return m_ins != null;
		}
		set{
			if (isLoaded != value)
			{
				if (value)
				{
					Load ();
				}
				else
				{
					Unload ();
				}
			}
		}
	}

	[HideInInspector][SerializeField]
	private GameObject m_ins = null;

	protected void Awake ()
	{
		if (mode == Mode.LoadOnAwake)
		{
			Debug.Assert (!isLoaded, "Invalid link state", gameObject);
			this.Call (Load, delay);
		}
	}

	[ContextMenu ("Load")]
	public void Load ()
	{
		if (m_ins == null)
		{
			if (prefab != null)
			{
				m_ins = prefab.Create (transform);
			}
		}
	}

	[ContextMenu ("Unload")]
	public void Unload ()
	{
		if (m_ins != null)
		{
			m_ins.Destroy ();
			m_ins = null;
		}
	}

	public void Switch ()
	{
		if (m_ins == null)
		{
			Load ();
		}
		else
		{
			Unload ();
		}
	}
}
