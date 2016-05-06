using UnityEngine;
using System.Collections;

namespace Demo3
{
	public class Bullet : MonoBehaviour
	{
		public int damage = 1;
		public float speed = 20f;
		private void Update()
		{
			transform.position
				+= transform.forward * speed * Time.deltaTime;
		}
		private void OnTriggerEnter(Collider collider)
		{
			var obj = collider.GetComponent<Character> ();
			if (obj != null) {
			}
			Object.Destroy (gameObject);
		}
	}
}