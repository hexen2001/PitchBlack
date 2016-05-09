using UnityEngine;
using System.Collections;

namespace Demo3
{
public class Manager : MonoBehaviour {

		public Marine marine;
		public Transform bulletLayer;
		public static Manager main
		{
			get{
				if (null == m_main)
				{
					m_main = GameObject.FindObjectOfType<Manager> ();
				}
				return m_main;
			}
		}
		private static Manager m_main = null;
}
}