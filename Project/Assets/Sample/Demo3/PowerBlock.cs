using UnityEngine;
using System.Collections;

namespace Demo3
{
	public class PowerBlock : MonoBehaviour {
		public Transform target;
		public float mark = 0f;
		public float speed = 0.1f;
		public float power = 1f;
		public bool isOpening = false;
		void Update()
		{
			if (isOpening)
			{
				mark += Time.deltaTime * speed;
			}
			else
			{
				mark -= Time.deltaTime * speed;
			}
			if (mark >= 1f)
			{
				OnOpen ();
			}
			mark = Mathf.Clamp01 (mark);

			UpdateMark ();	
		}
		private void UpdateMark()
		{
			var pos = target.localPosition;
			pos.y = ( 1 - mark ) * 2 - 1;
			target.localPosition = pos;
		}
		private void OnOpen()
		{
			Manager.main.marine.power += power;
			Object.Destroy (gameObject);
		}
		void OnTriggerEnter(Collider collider)
		{
			isOpening = true;
		}
		void OnTriggerExit(Collider collider)
		{
			isOpening = false;
		}
	}
}