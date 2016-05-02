using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	protected void OnTriggerEnter(Collider collider)
	{
		collider.gameObject.SendMessage ( "OnHit", this,
			SendMessageOptions.DontRequireReceiver);
		Destroy (gameObject);
	}

}
