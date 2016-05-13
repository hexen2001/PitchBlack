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
		public void AddResource(ResourceType resourceType, float value)
		{
			switch(resourceType)
			{
			case ResourceType.Power:
				m_power += value;
				break;
			case ResourceType.Metal:
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