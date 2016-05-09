// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Pitch Black")]
	public class ActFire : ActionBase<Character>
	{
		public FsmEvent ok;
		public FsmEvent fail;
		public override void OnLogic()
		{
			if (self.Fire ())
			{
				Fsm.Event (ok);
			}
			else
			{
				Fsm.Event (fail);
			}
			
		}
	}
}