using UnityEngine;
using System.Collections;

namespace Demo4
{
	public class PowerLight : MonoBehaviour
	{
		public Transform lightObj = null;
		[SerializeField]
		private float m_power = 100f;
		[SerializeField]
		private float m_powerMax = 100f;
		public float power
		{
			get
			{
				return m_power;
			}
			set
			{
				m_power = Mathf.Clamp( value, 0f, m_powerMax );
				UpdateLightState();
			}
		}
		public float consumeSpeed = 1f;
		public Vector3 lightScale = Vector3.one;
		public bool open
		{
			get
			{
				return m_open;
			}
			set
			{
				if( m_open != value )
				{
					m_open = value;
					UpdateLightState();
				}
			}
		}
		public bool isLightUp
		{
			get
			{
				return lightObj.gameObject.activeSelf;
			}
			private set
			{
				if( lightObj.gameObject.activeSelf != value )
				{
					lightObj.gameObject.SetActive( value );
				}
			}
		}
		private bool m_open = true;
		void Awake()
		{
			UpdateSelf();
		}
		protected void Update()
		{
			UpdateSelf();
		}
		private void UpdateLightState()
		{
			isLightUp = open && power > 0f;
		}
		private void UpdateSelf()
		{
			if( null != lightObj && isLightUp )
			{
				power -= Time.deltaTime * consumeSpeed;
				lightObj.localScale = Vector3.Lerp( lightObj.localScale, lightScale, 0.1f );
			}
			else
			{
				isLightUp = false;
			}
		}
	}
}
