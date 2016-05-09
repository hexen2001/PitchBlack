using UnityEngine;
using System.Collections.Generic;

namespace Demo4
{
	public class Game : Single<Game>
	{
		public int matal
		{
			get;
			private set;
		}
		public int power
		{
			get
			{
				return (int)m_power;
			}
		}
		private void Awake()
		{
			matal = 0;
			m_power = 0f;
		}
		public int refineryCount
		{
			get{
				return refineryList.Count;
			}
		}
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
		public void AddPower(float value)
		{
			m_power += value;
		}
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