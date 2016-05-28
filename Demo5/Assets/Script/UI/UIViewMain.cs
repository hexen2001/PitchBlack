using UnityEngine;
using System.Collections;

public class UIViewMain : UIView
{
	public string nextState;
	public void StartGame()
	{
		Manager.main.uiMngr.state = nextState;
	}
}
