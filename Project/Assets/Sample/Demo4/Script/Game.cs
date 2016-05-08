using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
	public int matal = 0;
	public int power = 0;
	public int refinecyCount = 0;
	public void AddPower(float value)
	{
		m_power += value;
		power = (int)m_power;
	}
	private float m_power = 0f;
	void OnGUI()
	{
		GUILayout.BeginVertical ();
		GUILayout.Label ("Matal:" + matal);
		GUILayout.Label ("Power:" + power);
		GUILayout.Label ("refinecyCount:" + refinecyCount);
		GUILayout.EndVertical ();
	}
}
