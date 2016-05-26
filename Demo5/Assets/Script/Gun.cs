using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
	public Bullet bulletPrefab;
	public Transform mark = null;
	public float cooldownTime = 1.5f;
	public bool isCanFire
	{
		get
		{
			return !isCooldown && bulletPrefab != null;
		}
	}
	public bool isCooldown
	{
		get
		{
			return m_endCooldownTime > Time.time;
		}
	}
	public float fireRange;
	private float m_endCooldownTime = 0f;
	private void StartCooldown()
	{
		m_endCooldownTime = Time.time + cooldownTime;
	}
	public Bullet Fire()
	{
		if( isCanFire )
		{
			var go = bulletPrefab.gameObject.Create(
				Manager.main.buildingLayer,
				mark != null ? mark : transform );

			var result = go.GetComponent<Bullet>();

			StartCooldown ();

			return result;
		}
		else
		{
			return null;
		}
	}
}
