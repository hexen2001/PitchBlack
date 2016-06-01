using UnityEngine;
using System.Collections;

[System.Serializable]
public struct GridPoint
{
	public const float GridSize = 2f;
	public GridPoint (int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	public GridPoint (int x, int y, int z)
	{
		this.x = x;
		this.y = y;
	}
	public GridPoint(Vector3 v)
	{
		x = 0;
		y = 0;
		FromVector3 (v);
	}

	public Vector3 ToVector3()
	{
		return new Vector3 (x*GridSize, 0f, y*GridSize);
	}
	public void FromVector3(Vector3 v)
	{
		if (v.x > 0)
		{
			x = (int)(( v.x + GridSize / 2 ) /GridSize);
		}
		else
		{
			x = (int)(( v.x - GridSize / 2 ) /GridSize);
		}
		if (v.z > 0)
		{
			y = (int)(( v.z + GridSize / 2 ) /GridSize);
		}
		else
		{
			y = (int)(( v.z - GridSize / 2 ) /GridSize);
		}
	}

	public int x;
	public int y;
}

[ExecuteInEditMode]
public abstract class GridObj : MonoBehaviour
{
	public GridPoint gridPoint
	{
		get
		{
			return m_gridPoint;
		}
	}

	public GridPoint GetGridPointNow ()
	{
		return new GridPoint (transform.position);
	}

	[SerializeField]
	private GridPoint m_gridPoint;

	public Vector3 GetGridPos ()
	{
		var gp = new GridPoint( transform.position );
		return gp.ToVector3();
	}

	protected void Awake ()
	{
//		GridMngr.main.Add (this);
	}

	protected void OnDestroy ()
	{
//		GridMngr.main.Remove (this);
	}

	protected virtual void Update ()
	{
		m_gridPoint = GetGridPointNow ();
	}
}

[ExecuteInEditMode]
public class GridMapLayout : GridObj
{

	#if UNITY_EDITOR
	protected override void Update ()
	{
		base.Update ();	
		transform.position = GetGridPos ();
	}

	#endif
}
