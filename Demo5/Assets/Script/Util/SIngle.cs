using UnityEngine;
using System.Collections;


public class Single<T> : MonoBehaviour
	where T : MonoBehaviour
{
	public static T main
	{
		get
		{
			if (!loaded)
			{
				m_main = Object.FindObjectOfType<T> ();
			}
			return m_main;
		}
	}

	public static bool loaded
	{
		get
		{
			return m_main != null;
		}
	}

	private static T m_main = null;
}
