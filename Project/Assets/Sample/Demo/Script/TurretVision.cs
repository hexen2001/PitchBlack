using UnityEngine;
using System.Collections.Generic;

public class TurretVision : MonoBehaviour
{
	public List<GameObject> target = new List<GameObject>();
	void OnTriggerEnter(Collider collider)
	{
		target.Add (collider.gameObject);
	}
	void OnTriggerExit(Collider collider)
	{
		target.Remove (collider.gameObject);
	}
}
