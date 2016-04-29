using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
	public TurretVision vision;
	public Gun gun;
	private GameObject target = null;
	public void Fire()
	{
		gun.Fire ();
	}
	void Update()
	{
		if (target == null)
		{
		}
		else
		{
		}
	}
}
