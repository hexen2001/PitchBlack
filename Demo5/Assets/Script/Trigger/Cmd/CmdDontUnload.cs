using UnityEngine;
using System.Collections;

public class CmdDontUnload : Cmd
{

	public GameObject target;

	protected override void OnDo ()
	{
		if( target !=null)
		{
			Object.DontDestroyOnLoad (target);
		}
	}
}
