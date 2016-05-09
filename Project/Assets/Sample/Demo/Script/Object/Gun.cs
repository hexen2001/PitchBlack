using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
	public float cooldown = 0.3f;
	private float m_lastFireTime;
	public GameObject bulletPrefab;
	public bool debugFire = false;
	void Update()
	{
		if (debugFire)
		{
			debugFire = !debugFire;
			Fire ();
		}
	}
	public bool IsCooldown
	{
		get{
			return ( m_lastFireTime + cooldown ) > Time.time;
		}
	}
	public GameObject Fire()
	{
		var result = Object.Instantiate (bulletPrefab) as GameObject;
		var tf = result.transform;
		tf.parent = transform;
		tf.localScale = Vector3.one;
		tf.localPosition = Vector3.zero;
		tf.localEulerAngles = Vector3.zero;
		tf.parent = Manager.main.bulletLayer;

		m_lastFireTime = Time.time;
		return result;
	}
}
