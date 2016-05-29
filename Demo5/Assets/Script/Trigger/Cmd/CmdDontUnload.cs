using UnityEngine;
using System.Collections;

public class CmdDontUnload : Cmd
{

	public GameObject[] targets;

	protected override void OnDo ()
	{
		foreach (var target in targets)
		{
			Object.DontDestroyOnLoad (target);
		}
	}
}
