using UnityEngine;
using System.Collections;

public class CmdSetGameState : Cmd {

	public string stateName;
	protected override void OnDo()
	{
		Manager.main.gameState.state = stateName;
	}
}
