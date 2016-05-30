using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridMngr : Single<GridMngr>
{
	public GridObj Get(GridPoint point)
	{
		foreach(var obj in m_gridTable)
		{
			if(obj.gridPoint == point )
			{
			}
		}
		return null;
	}
	public void Add(GridObj grid)
	{
	}
	public void Remove(GridObj grid)
	{
	}
	private List<GridObj> m_gridTable = new List<GridObj>();
}
