using UnityEngine;
using System.Collections;

public static class InputUtil
{
	public static bool GetInputDir(out Vector2 dir)
	{
		bool result = false;
		dir = new Vector2( 0f, 0f );
		if( Input.GetKey( KeyCode.W ) )
		{
			dir.y += 1;
			result = true;
		}
		if( Input.GetKey( KeyCode.A ) )
		{
			dir.x -= 1;
			result = true;
		}
		if( Input.GetKey( KeyCode.S ) )
		{
			dir.y -= 1;
			result = true;
		}
		if( Input.GetKey( KeyCode.D ) )
		{
			dir.x += 1;
			result = true;
		}
		return result;
	}
	public static bool GetWorldInputDir(out Vector3 dir)
	{
		Vector2 dir2d;
		if( InputUtil.GetInputDir( out dir2d ) )
		{
			dir = Camera.main.cameraToWorldMatrix.MultiplyVector( dir2d ).normalized;
			dir.y = 0f;
			dir.Normalize();
			return true;
		}
		else
		{
			dir = Vector3.zero;
			return false;
		}
	}
}
