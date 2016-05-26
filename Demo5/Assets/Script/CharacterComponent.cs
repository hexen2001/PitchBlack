using UnityEngine;
using System.Collections;

public class CharacterComponent : MonoBehaviour
{
	protected Character self
	{
		get{
			if (null == m_self)
			{
				m_self = GetComponent<Character> ();
			}
			return m_self;
		}
	}
	private Character m_self = null;
}
