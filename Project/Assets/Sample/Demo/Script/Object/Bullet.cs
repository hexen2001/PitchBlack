using UnityEngine;
using System.Collections;

namespace Demo4
{
	public class Bullet : MonoBehaviour
	{
		public int damagePoint = 0;
		public GameObject hitEffect = null;
		protected void OnTriggerEnter(Collider collider)
		{
			collider.gameObject.SendMessage ( "OnHit", this,
				SendMessageOptions.DontRequireReceiver);

			if (hitEffect != null)
			{
				var go = hitEffect.Create (collider.transform);
				var tf = go.transform;
				tf.parent = Demo4.Manager.main.bulletLayer;
			}


			Destroy (gameObject);
		}

	}
}