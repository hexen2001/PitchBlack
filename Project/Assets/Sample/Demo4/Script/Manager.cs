using UnityEngine;
using System.Collections;


namespace Demo4
{

	public class Single<T> : MonoBehaviour
		where T : MonoBehaviour
	{
		public static T main
		{
			get{
				if (null == m_main)
				{
					m_main = Object.FindObjectOfType<T> ();
				}
				return m_main;
			}
		}
		private static T m_main = null;
	}
	public class Manager : Single<Manager>
	{
		public Game game;

	}

}