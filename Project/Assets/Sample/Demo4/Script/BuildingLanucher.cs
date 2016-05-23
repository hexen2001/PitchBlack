using UnityEngine;
using System.Collections;

namespace Demo4
{
	public class BuildingLanucher : MonoBehaviour
	{
		public GameObject prefab;
		public Title title;
		public float process
		{
			get
			{
				return (Time.time - m_startTime) / time;
			}
		}
		public float time = 3;
		public float m_startTime = 0;
		void Start()
		{
			m_startTime = Time.time;
		}
		void Update()
		{
			if (0f <= process && process <= 1f)
			{
				title.text = "Launcher:" + ((int)(process * 100)) + "%";
			}
			else
			{
				var go = prefab.Create (transform);
				go.transform.parent = Manager.main.buildingLayer;
				Object.Destroy (gameObject);
			}
		}
	}
}