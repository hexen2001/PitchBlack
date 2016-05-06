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

			if (null != hitEffect)
			{
				var fx = Instantiate (hitEffect) as GameObject;
				var tf = fx.transform;
				tf.parent = collider.transform;
				tf.localScale = Vector3.one;
				tf.localEulerAngles = Vector3.zero;
				tf.localPosition = Vector3.zero;
				tf.parent = Manager.main.bulletLayer;
			}

			Destroy (gameObject);
		}
	}
}