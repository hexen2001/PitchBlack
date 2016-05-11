using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Demo4
{
	public class Character : MonoBehaviour
	{
		private const float corpseDestroyDelay = 5f;
		public int hp = 100;
		public int hpMax = 100;
		public bool isLife
		{
			get{
				return m_isLife;
			}
			private set{
				m_isLife = value;
			}
		}
		[SerializeField]
		private bool m_isLife = true;
		public float powerRecoverSpeed = 0f;
		public PowerLight powerLight = null;
		public MarineBeHit beHit;
		public void Damage(int damagePoint)
		{
			hp = Mathf.Clamp (hp - damagePoint, 0, hpMax);
			if (isLife)
			{
				if (hp == 0)
				{
					Die ();
				}
			}
		}
		private void Die()
		{
			isLife = false;
			hp = 0;
			Destroy (gameObject, corpseDestroyDelay);
		}
		public float power
		{
			get
			{
				if( powerLight == null )
				{
					return 0f;
				}
				return powerLight.power;
			}
			set
			{
				if( powerLight == null )
				{
					return;
				}
				powerLight.power = value;
			}
		}
		public bool isFreePowerMode
		{
			get{
				return powerRecoverSpeed > 0f;
			}
		}
		public List<BuffField> buffFields = new List<BuffField>();
		protected void Update()
		{
			if( powerRecoverSpeed > 0f )
			{
				power += powerRecoverSpeed * Time.deltaTime;
			}
			powerLight.isFreePowerMode = isFreePowerMode;

			if (beHit.enabled == powerLight.isLightUp)
			{
				beHit.enabled = !powerLight.isLightUp;
			}
		}
		protected void UpdateBuffField()
		{
			powerRecoverSpeed = 0f;
			foreach( var field in buffFields )
			{
				if( field != null )
				{
					powerRecoverSpeed += field.powerRecoverSpeed;
				}
			}
		}
		protected void OnTriggerEnter(Collider collider)
		{
			var powerRecoverField = collider.gameObject.GetComponent<BuffField>();
			if( powerRecoverField != null )
			{
				buffFields.Add( powerRecoverField );
				UpdateBuffField();
			}
		}
		protected void OnTriggerExit(Collider collider)
		{
			var recoverField = collider.gameObject.GetComponent<BuffField>();
			if( recoverField != null )
			{
				buffFields.Remove( recoverField );
				UpdateBuffField();
			}
		}
	}
}