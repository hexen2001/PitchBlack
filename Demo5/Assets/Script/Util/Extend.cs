using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public static class ExtendGameObject
{


	public static GameObject Create(this GameObject prefab, Transform parent)
	{
		GameObject go = null;

		#if UNITY_EDITOR
		if (!Application.isPlaying)
		{
			go = PrefabUtility.InstantiatePrefab (prefab) as GameObject;
		}
		else
		#endif
		{
			go = Object.Instantiate (prefab) as GameObject;
		}


		var tf = go.transform;
		/*
		if (tf is RectTransform )
		{
			if (parent is RectTransform)
			{
				(tf as RectTransform).parent = parent;
			}
		}
		else
		*/
		{
			tf.parent = parent;
		}

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
