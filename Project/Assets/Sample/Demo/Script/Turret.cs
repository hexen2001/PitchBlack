using UnityEngine;
using System.Collections;

public class Turret : Character {
	public Vision vision;
	public Gun gun;
	private GameObject target = null;
	public void Fire()
	{
		var go = gun.Fire ();
		if (go != null)
		{
			go.layer = (int)fireLayer;
		}
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
