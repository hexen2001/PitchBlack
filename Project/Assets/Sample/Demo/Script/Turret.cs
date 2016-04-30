using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
	public Vision vision;
	public Gun gun;
	private GameObject target = null;
	public void Fire()
	{
		gun.Fire ();
	}
	void Update()
	{
		gun.target = vision.first;
		if (target == null)
		{
		}
		else
		{
		}
	}
}
