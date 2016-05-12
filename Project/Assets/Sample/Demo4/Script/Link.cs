using UnityEngine;
using System.Collections;

public static class ExtendGameObject
{
	public static GameObject Create (this GameObject prefab, Transform parent)
	{
		var go = Object.Instantiate (prefab) as GameObject;
		var tf = go.transform;
		tf.parent = parent;
		tf.name = prefab.name;

		var ptf = prefab.transform;
		tf.localPosition = ptf.localPosition;
		tf.localScale = ptf.localScale;
		tf.localRotation = ptf.localRotation;

		return go;
	}

	public static void Destroy (this GameObject self)
	{
		DestroyObject (self);
	}

	public static void Destroy (this Component self)
	{
		DestroyObject (self);
	}

	private static void DestroyObject (this Object self)
	{
		if (Application.isPlaying)
		{
			Object.Destroy (self);
		}
		else
		{
			Object.DestroyImmediate (self);
		}
	}
}

public class Link : MonoBehaviour
{
	public enum Mode
	{
		Manual,
		LoadOnAwake,
	}

	public Mode mode = Mode.Manual;
	
	public GameObject prefab = null;

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
			Load ();
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
