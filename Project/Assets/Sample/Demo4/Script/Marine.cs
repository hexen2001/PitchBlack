using UnityEngine;
using System.Collections;

namespace Demo4
{
	public class Marine : MonoBehaviour
	{
		public GameObject lightObj;
		void Awake()
		{
			UpdateLight ();
		}
		public bool open
		{
			get{
				return m_open;
			}
			set{
				if (m_open != value)
				{
					if (power > 0)
					{
						m_open = value;
					}
				}
			}
		}
		public int power = 100;
		public int powerMax = 100;
		public float powerConsumeSpeed = 5f;
		private float m_power = 100f;
		public bool m_open = false;

		void UpdatePowerAndLight()
		{
			if (open)
			{
				if (power > 0f)
				{
					m_power -= powerConsumeSpeed * Time.deltaTime;
					power = (int)m_power;
				}
				else
				{
					open = !open;
					UpdateLight ();
				}
			}
		}
		void UpdateLight()
		{
			lightObj.SetActive (open);
		}
	}
}