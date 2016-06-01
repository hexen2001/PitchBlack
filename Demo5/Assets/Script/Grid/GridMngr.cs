using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridMngr : Single<GridMngr>
{
	public GridObj Get (GridPoint point)
	{
		foreach (var obj in m_gridTable)
		{
		}
		return null;
	}

	public void Add (GridObj grid)
	{
	}

	public void Remove (GridObj grid)
	{
	}

	[SerializeField]
	private List<GridObj> m_gridTable = new List<GridObj> ();
}
