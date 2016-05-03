using UnityEngine;
using System.Collections;

namespace Demo2
{
	public class MoveDir : MonoBehaviour
	{
		public float speed = 6f;
		void Update()
		{
			transform.position += Vector3.forward * speed * Time.deltaTime;
		}
	}
}