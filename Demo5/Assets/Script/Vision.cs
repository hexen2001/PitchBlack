using UnityEngine;
using System.Collections.Generic;


public abstract class Vision : TouchBase
{


	public abstract Object first
	{
		get;
	}



	protected override void UpdateLayer ()
	{
		gameObject.layer = CampUtil.FireLayer (camp);
	}


}