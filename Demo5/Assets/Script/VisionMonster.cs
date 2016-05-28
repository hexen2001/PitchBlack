using UnityEngine;
using System.Collections;

public class VisionMonster : VisionRange
{
	private bool CheckValid (GameObject go)
	{
		var marine = go.GetComponent<Marine> ();
		if (marine != null)
		{
			if (marine.lighting)
			{
				return false;
			}
		}
		return true;
	}

	public override GameObject first
	{
		get
		{
			foreach (var go in m_targets)
			{
				if (go != null)
				{
					if (CheckValid (go))
					{
						return go;
					}
				}
			}
			return null;
		}
	}

}
