using UnityEngine;
using System.Collections;

namespace Demo4
{
	public static class MathUtil
	{
		public static Vector3 DirAt(Vector3 origion, Vector3 target)
		{
			if (origion != target)
			{
				return (target - origion).normalized;
			}
			else
			{
				Debug.LogError("DirAt():origion == target!");
				return Vector3.zero;
			}
		}
		public static Vector3 DirAt2D(Vector3 origion, Vector3 target)
		{
			if (origion != target)
			{
				var dir = (target - origion);
				dir.y = 0f;
				return dir.normalized;
			}
			else
			{
				Debug.LogError("DirAt():origion == target!");
				return Vector3.zero;
			}
		}
	}
}