using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour {
	public float delay = 1f;
	void Start ()
	{
		Object.Destroy (gameObject, delay);

	}
}
