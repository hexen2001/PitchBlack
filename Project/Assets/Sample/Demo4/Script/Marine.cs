using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Demo3;

namespace Demo4
{
	public class Marine : MonoBehaviour
	{
		public NavMeshAgent nav;
		public Character character;
		public float speed = 6;
		public float accSpeed = 10f;
		private float m_speed = 0f;
		protected void Update()
		{
			Vector3 dir;
			if( InputUtil.GetWorldInputDir( out dir ) )
			{
				nav.Move( dir * m_speed * Time.deltaTime );
				m_speed = Mathf.Clamp( m_speed + accSpeed * Time.deltaTime, 0f, speed );
			}
			else
			{
				m_speed = Mathf.Clamp( m_speed - accSpeed * Time.deltaTime, 0f, speed );
			}

			transform.rotation = Quaternion.Slerp(
				transform.rotation,
				Quaternion.LookRotation( dir, transform.up ),
				0.1f ); ;
		}
	}
}