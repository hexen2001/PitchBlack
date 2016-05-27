using UnityEngine;
using System.Collections.Generic;


public abstract class Vision : TouchBase
{


	public abstract GameObject first
	{
		get;
	}



	public abstract List<GameObject> targets
	{
		get;
	}



}