using UnityEngine;
using System.Collections.Generic;

public abstract class Event : MonoBehaviour
{
	public Object target = null;
	private enum TargetType
	{
		Unknown,
		Cmd,
		GameObject,
	}
	private TargetType m_targetType;
	protected virtual void Awake()
	{
		if (target == null)
		{
			target = gameObject;
		}

		if (target is GameObject)
		{
			m_targetType = TargetType.GameObject;
		}
		else if (target is Cmd)
		{
			m_targetType = TargetType.Cmd;
		}
		else
		{
			m_targetType = TargetType.Unknown;
			Debug.LogWarning ( "Unknown target." );
		}
	}
	private List<Condition> conditions
	{
		get{
			if (null == m_conditions)
			{
				m_conditions = new List<Condition> (GetComponents<Condition>());
			}
			return m_conditions;
		}
	}
	private List<Condition> m_conditions = null;
	[ContextMenu("Raise")]
	public void Raise()
	{
		for( int i = 0; i < conditions.Count; ++i )
		{
			if (!conditions [i].Check ())
			{
				return;
			}
		}

		switch (m_targetType)
		{
		case TargetType.Cmd:
			(target as Cmd).SendMessage ("Do",
				SendMessageOptions.DontRequireReceiver);
			break;
		case TargetType.GameObject:
			(target as GameObject).SendMessage ("Do",
				SendMessageOptions.DontRequireReceiver);
			break;
		}
	}
}