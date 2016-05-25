using UnityEngine;
using System.Collections.Generic;

public class VisionRange : Vision
{
	public override Character target
	{
		get
		{
			if (targets.Count > 0)
			{
				return targets [0];
			}
			return null;
		}
	}

	public List<Character> targets = new List<Character> ();

	protected override void OnEnter (Character target)
	{
		targets.Add (target);
	}

	protected override void OnExit (Character target)
	{
		targets.Remove (target);
	}

	protected void Update ()
	{
		targets.RemoveAll (obj => obj == null);
	}
}
