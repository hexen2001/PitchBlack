using UnityEngine;
using System.Collections;

namespace Demo4
{
	public class CameraTrack : MonoBehaviour
	{
		public Transform target;
		public Transform cameraAt;
		public float tweenScale= 0.3f;
		void Start()
		{
			cameraAt.position = target.position;
		}
		void Update ()
		{
			if (target != null && cameraAt != null)
			{
				cameraAt.position = Vector3.Lerp
					(cameraAt.position, target.position, tweenScale);
			}
		}
	}
}