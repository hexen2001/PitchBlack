using UnityEngine;
using System.Collections.Generic;

public class Vision : TouchBase
{
	public List<Character> targets = new List<Character>();
	protected override void UpdateLayer()
	{
		gameObject.layer = CampUtil.FireLayer( camp );
	}
	protected override void OnEnter(Character target)
	{
		targets.Add( target );
	}
	protected override void OnExit(Character target)
	{
		targets.Remove( target );
	}
}
