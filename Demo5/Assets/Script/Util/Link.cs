using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class Link : MonoBehaviour
{
	public enum Mode
	{
		Manual,
		LoadOnAwake,
		EnableToDisable,
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
		set
		{
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

	[ContextMenu ("Open")]
	public void Load ()
	{
		if (m_ins == null)
		{
			if (prefab != null)
			{
				{
					m_ins = prefab.Create (transform);
				}
			}
		}
	}

	[ContextMenu ("Close")]
	public void Unload ()
	{
		if (m_ins != null)
		{
			m_ins.Destroy ();
			m_ins = null;
		}
	}

	#if UNITY_EDITOR
	[ContextMenu ("Save and close")]
	public void SaveAndClose ()
	{
		if (m_ins != null)
		{
			if (prefab != null)
			{
				PrefabUtility.ReplacePrefab (m_ins, prefab);
			}
			m_ins.Destroy ();
			m_ins = null;
		}
	}
	#endif

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

	protected void OnEnable ()
	{
		if (mode == Mode.EnableToDisable)
		{
			if (m_ins == null)
			{
				Load ();
			}
		}
	}

	protected void OnDisable ()
	{
		if (mode == Mode.EnableToDisable)
		{
			if (m_ins != null)
			{
				m_ins.Destroy ();
				m_ins = null;
			}
		}
	}
}
