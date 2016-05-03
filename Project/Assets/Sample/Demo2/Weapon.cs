using UnityEngine;
using System.Collections;

namespace Demo2
{
	public class Weapon : MonoBehaviour
	{
		public Bullet prefab;
		public float cooldownTime = 1.5f;
		public bool isCooldown
		{
			get{
				return m_lastFireTime + cooldownTime > Time.time;
			}
		}
		private float m_lastFireTime = -100f;
		public Bullet Fire(Role attacker)
		{
			var obj = ( Instantiate (prefab.gameObject) as GameObject ) .GetComponent<Bullet>();
			obj.attacker = attacker;

			var tf = obj.transform;
			tf.parent = transform;
			tf.localScale = Vector3.one;
			tf.localPosition = Vector3.zero;
			tf.localEulerAngles = Vector3.zero;
			tf.parent = Manager.main.bulletLayer.transform;

			m_lastFireTime = Time.time;
			return obj;
		}
	}
}