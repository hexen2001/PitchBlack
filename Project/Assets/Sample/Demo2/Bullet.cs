using UnityEngine;
using System.Collections;

namespace Demo2
{
	public class Bullet : MonoBehaviour
	{
		public Role attacker = null;
		public int damagePoint = 1;
		public GameObject hitEffect;
		public void OnTriggerEnter(Collider collider)
		{
			collider.gameObject.SendMessage ("OnHit",this,
				SendMessageOptions.DontRequireReceiver);
			Destroy (gameObject);
		}
	}
}