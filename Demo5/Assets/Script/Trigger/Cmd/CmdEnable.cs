using UnityEngine;
using System.Collections;

public class CmdEnable : Cmd
{
	public Behaviour target;
	public enum Mode
	{
		Enable,
		Disable,
		Toggle,
	}
	public Mode mode = Mode.Enable;
	protected override void OnDo()
	{
		switch( mode )
		{
			case Mode.Enable:
				target.enabled = true;
				break;
			case Mode.Disable:
				target.enabled = false;
				break;
			case Mode.Toggle:
				target.enabled = !target.enabled;
				break;
		}
	}
}
