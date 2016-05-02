using UnityEngine;
using System.Collections;

namespace Demo2
{
	public class Bullet : MonoBehaviour
	{
		public Role attacker;
		public int damagePoint;
		public GameObject hitEffect;
		public void OnTriggerEnter(Collider collider)
		{
			collider.gameObject.SendMessage ("OnHit",this,
				SendMessageOptions.DontRequireReceiver);
		}
	}
}