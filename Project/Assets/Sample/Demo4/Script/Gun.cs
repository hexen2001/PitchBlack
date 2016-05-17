using UnityEngine;
using System.Collections;
namespace Demo4
{
	public class Gun : MonoBehaviour
	{
		public float cooldown = 0.3f;
		private float m_lastFireTime;
		public GameObject bulletPrefab;
		public Transform mark;
		public bool debugFire = false;
		public int damagePoint = 1;
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
			var go = bulletPrefab.Create (mark);
			var tf = go.transform;
			tf.parent = Manager.main.bulletLayer;

			m_lastFireTime = Time.time;

			go.GetComponent<Bullet> ().damagePoint = damagePoint;
			return go;
		}
	}
}