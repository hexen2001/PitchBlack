using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Demo4
{
	public class Character : MonoBehaviour
	{
		public float powerRecoverSpeed = 0f;
		public PowerLight powerLight = null;
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
		public List<BuffField> buffFields = new List<BuffField>();
		protected void Update()
		{
			if( powerRecoverSpeed > 0f )
			{
				power += powerRecoverSpeed * Time.deltaTime;
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