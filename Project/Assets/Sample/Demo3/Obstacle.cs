using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
	public NavMeshObstacle target;
	private Vector3 m_lastPosition;
	void Awake()
	{
		m_lastPosition = transform.position;
	}
	private bool CheckMove()
	{
		if ((transform.position - m_lastPosition).magnitude > 1f)
		{
			m_lastPosition = transform.position;
			return true;
		}
		return false;
	}
	private float m_lastMoveTime = 0f;
	void Update()
	{
		if (target.enabled)
		{
			if (CheckMove ())
			{
				Debug.Log ("enable = false;");
				target.enabled = false;
			}
		}
		else
		{
			if (CheckMove ())
			{
				m_lastMoveTime = Time.time;
			}
			if (Time.time - m_lastMoveTime > 1f)
			{
				Debug.Log ("enable = true;");
				target.enabled = true;
			}
		}
	}
}
