using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour {
	public GameObject target;
	public float intervals = 1;
	private float m_nextTime = 0f;
	protected void Update()
	{
		if (m_nextTime <= 0)
		{
			m_nextTime = intervals;
			target.SetActive (!target.activeSelf);
		}
		m_nextTime -= Time.deltaTime;
	}
}
