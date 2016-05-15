using UnityEngine;
using System.Collections.Generic;

namespace Demo4
{
	public class Game : Single<Game>
	{
		public int matal
		{
			get
			{
				return (int)m_metal;
			}
		}
		public int power
		{
			get
			{
				return (int)m_power;
			}
		}
		public int refineryCount
		{
			get{
				return refineryList.Count;
			}
		}
		public Marine marine;
		public List<Refinery> refineryList = new List<Refinery>();
		public static void AddRefinery(Refinery refinery)
		{
			if( main != null )
			{
				main.refineryList.Add( refinery );
			}
		}
		public static void RemoveRefinery(Refinery refinery)
		{
			if( main != null )
			{
				main.refineryList.Remove( refinery );
			}
		}
		public bool CheckPay(params PayPair[] pairs)
		{
			foreach (var pair in pairs)
			{
				if (GetRes (pair.type) < pair.value)
				{
					return false;
				}
			}
			return true;
		}
		public void Pay(params PayPair[] pairs)
		{
			foreach (var pair in pairs)
			{
				AddRes (pair.type, pair.value);
			}
		}
		private int GetRes(ResType type)
		{
			switch(type)
			{
			case ResType.Power:
				return (int)m_power;
			case ResType.Metal:
			default:
				return (int)m_metal;
			}
		}
		private void SetRes(ResType type, int value)
		{
			switch(type)
			{
			case ResType.Power:
				m_power = value;
				break;
			case ResType.Metal:
			default:
				m_metal = value;
				break;
			}
		}
		private void AddRes(ResType type, int value)
		{
			switch(type)
			{
			case ResType.Power:
				m_power += value;
				break;
			case ResType.Metal:
			default:
				m_metal += value;
				break;
			}
		}
		[SerializeField]
		private float m_metal = 0f;
		[SerializeField]
		private float m_power = 0f;
		void OnGUI()
		{
			GUILayout.BeginVertical (GUI.skin.box);
			GUILayout.Label ("Matal:" + matal);
			GUILayout.Label ("Power:" + power);
			GUILayout.Label ("refinecyCount:" + refineryCount);
			GUILayout.EndVertical ();
		}
	}
}