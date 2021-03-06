﻿using UnityEngine;
using System.Collections;

public class Single<T> : MonoBehaviour
	where T : MonoBehaviour
{
	public static T main
	{
		get{
			if (null == m_main)
			{
				m_main = GameObject.FindObjectOfType<T> ();
			}
			return m_main;
		}
	}
	private static T m_main = null;
}
public class Manager : Single<Manager>
{
	public Transform bulletLayer;
	public ObjMngr objMngr;
}
