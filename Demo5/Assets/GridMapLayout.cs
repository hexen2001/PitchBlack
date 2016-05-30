using UnityEngine;
using System.Collections;

public struct GridPoint
{
	public GridPoint(int x, int y)
	{
		this.x = x;
		this.y = y;
		this.z = 0;
	}
	public GridPoint(int x, int y, int z)
	{
		this.x = x;
		this.y = y;
		this.z = z;
	}
	public static bool operator ==(GridPoint a, GridPoint b)
	{
		return false;
	}
	public static bool operator !=(GridPoint a, GridPoint b)
	{
		return false;
	}
	public int x;
	public int y;
	public int z;
}


public abstract class GridObj : MonoBehaviour
{
	public GridPoint gridPoint
	{
		get
		{
			var pos = GetGridPos();
			return new GridPoint( (int)pos.x, (int)pos.y, (int)pos.z );
		}
	}
	protected const float GridSize = 1f;
	public Vector3 GetGridPos()
	{
		var pos = transform.position;
		pos.x = pos.x - ( pos.x % GridSize );
		pos.y = pos.y - ( pos.y % GridSize );
		pos.z = pos.z - ( pos.z % GridSize );
		return pos;
	}
}

[ExecuteInEditMode]
public class GridMapLayout : GridObj
{

#if UNITY_EDITOR
	protected virtual void Update()
	{
		transform.position = GetGridPos();
	}

#endif
}
