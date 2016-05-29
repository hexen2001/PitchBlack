using UnityEngine;
using System.Collections;

public class CmdShowUI : Cmd
{
	public GameObject uiView;
	protected override void OnDo ()
	{
		Manager.main.uiMngr.state = uiView.name;
	}
}
