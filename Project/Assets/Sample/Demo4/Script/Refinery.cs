using UnityEngine;
using System.Collections;

namespace Demo4
{
	public enum ResType
	{
		Power,
		Metal,
	}
	public class Refinery : MonoBehaviour
	{
		public ResType resourceType = ResType.Power;
		public float speed = 1f;
		private float m_addValue = 0f;
		void Awake()
		{
			Game.AddRefinery(this);
		}
		void OnDestroy()
		{
			Game.RemoveRefinery( this );
		}
		void Update ()
		{
			m_addValue += speed * Time.deltaTime;
			if (m_addValue >= 1.0f)
			{
				int value = (int)m_addValue;
				m_addValue -= value;
				Manager.main.game.Add( new PayPair( resourceType, value ) );
			}
		}
	}
}