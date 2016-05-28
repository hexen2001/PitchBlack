using UnityEngine;
using System.Collections.Generic;



public class Monster : Character
{
	public float speed = 3.5f;
	public float crazySpeed = 10f;
	public List<GameObject> lights = new List<GameObject>();
	public override void AddLight(GameObject go)
	{
		base.AddLight (go);
		lights.Add (go);

	}
	public override void RemoveLight(GameObject go)
	{
		base.RemoveLight (go);
		lights.Remove (go);
	}
	private float currentSpeed
	{
		get
		{
			return lighting ? crazySpeed : speed;
		}
	}
	protected override void Update()
	{
		if (nav != null)
		{
			nav.speed = Mathf.Lerp (nav.speed, currentSpeed, 0.3f);
		}
		base.Update ();
	}
}