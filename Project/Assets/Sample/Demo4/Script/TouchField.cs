using UnityEngine;
using System.Collections;

public class TouchField : MonoBehaviour
{
	public GameObject target;
	public bool active = true;
	void OnTriggerEnter(Collider collider)
	{
		if (target != null)
		{
			target.SetActive (active);
		}
	}
	void OnTriggerExit(Collider collider)
	{
		if (target != null)
		{
			target.SetActive (!active);
		}
	}
}
