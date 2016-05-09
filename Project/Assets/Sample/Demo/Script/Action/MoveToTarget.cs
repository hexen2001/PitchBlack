// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Pitch Black")]
	public class MoveToTarget : ActionBase<Runner>
	{
		public FsmInt skillId;
		public FsmEvent ok;
		public FsmEvent fail;
		public override void OnLogic()
		{
			skillId = 1;
			Fsm.Event (ok);
			if (self.target == null)
			{
				Fsm.Event (fail);
				return;
			}

			self.nav.destination = self.target.transform.position;
			self.nav.stoppingDistance = (self.bodySize + self.target.GetComponent<Character> ().bodySize)/2;
			if (self.nav.hasPath || self.nav.isPathStale)
			{
			}
			else
			{
			}

		}
	}
}