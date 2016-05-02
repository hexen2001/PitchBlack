// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Pitch Black")]
	public class BeginAttack : ActionBase<Character>
	{
		public FsmInt skillId;
		public FsmEvent ok;
		public FsmEvent fail;
		public override void OnLogic()
		{
			skillId = 1;
			Fsm.Event (ok);
		}
	}
}