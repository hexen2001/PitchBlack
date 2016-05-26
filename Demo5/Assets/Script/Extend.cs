﻿using UnityEngine;
using System.Collections;

public static class ExtendGameObject
{


	public static GameObject Create(this GameObject prefab, Transform parent)
	{
		var go = Object.Instantiate( prefab ) as GameObject;
		var tf = go.transform;
		tf.parent = parent;
		tf.name = prefab.name;

		var ptf = prefab.transform;
		tf.localPosition = ptf.localPosition;
		tf.localScale = ptf.localScale;
		tf.localRotation = ptf.localRotation;

		return go;
	}


	public static GameObject Create(this GameObject prefab, Transform finalParent, Transform baseParent)
	{
		var go = Create( prefab, baseParent );
		go.transform.parent = finalParent;
		return go;
	}


	public static void Call(this MonoBehaviour self, System.Action func, float time)
	{
		self.StartCoroutine( _Call( func, time ) );
	}


	private static IEnumerator _Call(System.Action func, float time)
	{
		yield return new WaitForSeconds( time );
		func();
	}


	public static void Destroy(this GameObject self)
	{
		DestroyObject( self );
	}


	public static void Destroy(this Component self)
	{
		DestroyObject( self );
	}


	private static void DestroyObject(this Object self)
	{
		if( Application.isPlaying )
		{
			Object.Destroy( self );
		}
		else
		{
			Object.DestroyImmediate( self );
		}
	}


}
