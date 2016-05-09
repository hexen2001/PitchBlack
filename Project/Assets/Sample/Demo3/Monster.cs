using UnityEngine;
using System.Collections.Generic;


namespace Demo3
{	
	public class Monster : MonoBehaviour
	{
		public NavMeshAgent nav;
		public float speed = 7;
		public float acc = 5;
		public float fireRange = 1f;
		public float weaponCooldown = 1.5f;
		private float m_cooldownFinishedTime = 0f;

		private float m_currentSpeed;

		Vector3 CalcLightForcePushDir ()
		{
			var ptf = Manager.main.marine.transform;
			var p2 = ptf.position + ptf.forward * 50;
			var p1 = ptf.position;
			var p3 = transform.position;
			var dir = ((p3 - p2).normalized + (p3 - p1).normalized).normalized;
			return dir;
		}

		// Update is called once per frame
		void Update ()
		{
			Vector3 dir;
			float accRegular;
			if (list.Count == 0)
			{
				if (m_currentSpeed <= 0)
				{
					m_currentSpeed = 0f;
					nav.destination = Manager.main.marine.transform.position;

					if ((Manager.main.marine.transform.localPosition - transform.position).magnitude <= fireRange)
					{
						Fire ();
					}


					return;
				}
				dir = transform.forward;

				accRegular = -acc;
			}
			else
			{
				if (nav.hasPath)
				{
					nav.ResetPath ();
				}



//				dir = -(list [0].position - transform.position).normalized;
//				dir = -(Manager.main.marine.transform.position - transform.position).normalized;
				dir = CalcLightForcePushDir ();


				transform.forward = Vector3.Slerp( transform.forward, dir, 0.1f );

				accRegular = acc;
			}

			m_currentSpeed += accRegular * Time.deltaTime;
			m_currentSpeed = Mathf.Clamp (m_currentSpeed,0f,speed);

			var step = dir * m_currentSpeed * Time.deltaTime;
			nav.Move (step);
		}
		private void Shot()
		{
		}
		private void Fire()
		{
			if (Time.time > m_cooldownFinishedTime)
			{
				Shot ();
				m_cooldownFinishedTime = Time.time+weaponCooldown;
			}
		}
		List<Transform> list = new List<Transform> ();
		void OnTriggerEnter(Collider c)
		{
			list.Add (c.transform);
		}
		void OnTriggerExit(Collider c)
		{
			list.Remove (c.transform);
		}
	}
}