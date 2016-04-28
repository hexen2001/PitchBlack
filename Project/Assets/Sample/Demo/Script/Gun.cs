using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
	public GameObject bulletPrefab;
	public GameObject Fire()
	{
		var result = Object.Instantiate (bulletPrefab) as GameObject;
		var tf = result.transform;
		tf.parent = transform;
		tf.localScale = Vector3.one;
		tf.localPosition = Vector3.zero;
		tf.localEulerAngles = Vector3.zero;
		return result;
	}
}
