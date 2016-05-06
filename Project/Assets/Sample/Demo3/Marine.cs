using UnityEngine;
using System.Collections;

namespace Demo3
{
	public class Marine : Character {
		public GameObject lightForce;
		public float power = 50f;
		public float powerMax = 100f;
		public float powerConsume = 1f;
		public float speed = 7f;
		public float freeSpeed = 14f;
		public Vector3 dir;
		private static bool GetInputDir (out Vector2 dir)
		{
			bool result = false;
			dir = new Vector2(0f,0f);
			if (Input.GetKey (KeyCode.W))
			{
				dir.y += 1;
				result = true;
			}
			if (Input.GetKey (KeyCode.A))
			{
				dir.x -= 1;
				result = true;
			}
			if (Input.GetKey (KeyCode.S))
			{
				dir.y -= 1;
				result = true;
			}
			if (Input.GetKey (KeyCode.D))
			{
				dir.x += 1;
				result = true;
			}
			return result;
		}

		private static bool GetWorldInputDir (out Vector3 dir)
		{
			Vector2 dir2d;
			if (GetInputDir (out dir2d))
			{
				dir = Camera.main.cameraToWorldMatrix.MultiplyVector (dir2d).normalized;
				dir.y = 0f;
				dir.Normalize ();
				return true;
			}
			else
			{
				dir = Vector3.zero;
				return false;
			}
		}
		public void Update()
		{
			if (Input.GetKeyDown (KeyCode.J))
			{
				if (power > 0f)
				{
					lightForce.SetActive (!lightForce.activeSelf);
				}
			}
			if (GetWorldInputDir (out dir))
			{
				float realSpeed = lightForce.activeSelf ? speed : freeSpeed;
				var step = dir * realSpeed * Time.deltaTime;
				transform.position += step;
			}
			if (lightForce.activeSelf)
			{
				power -= powerConsume * Time.deltaTime;
				if (0 > power)
				{
					lightForce.SetActive (false);
				}
				power = Mathf.Clamp (power, 0f, powerMax);
			}

			transform.forward = Vector3.Slerp (transform.forward, dir, 0.2f);
		}
	}
}