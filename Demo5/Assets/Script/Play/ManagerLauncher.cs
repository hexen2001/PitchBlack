using UnityEngine;
using System.Collections;

public class ManagerLauncher : MonoBehaviour
{
	public Link link;

	protected void Awake ()
	{
		if (GameObject.FindObjectOfType<Manager> () == null)
		{
			Object.DontDestroyOnLoad (gameObject);
			link.Load ();
		}
		else
		{
			gameObject.Destroy ();
		}
	}
}
