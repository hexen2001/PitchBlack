// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Pitch Black")]
	public class ActVision : ActTurretBase
	{
		public FsmEvent onFound;
		public FsmEvent onLost;
		public enum EventMode
		{
			Enter,
			Update,
			All,
		}
		public EventMode eventMode = EventMode.All;
		public override void Awake()
		{
			base.Awake ();
		}
		private void CheckAndRaiseFoundEnemy()
		{
			if (turret!=null)
			{
				if (turret.vision.Empty)
				{
					Fsm.Event (onLost);
				}
				else
				{
					Fsm.Event (onFound);
				}
			}
		}
		public override void OnEnter()
		{
			switch (eventMode)
			{
			case EventMode.All:
			case EventMode.Enter:
				CheckAndRaiseFoundEnemy ();
				break;
			}
		}
		public override void OnUpdate()
		{
			switch(eventMode )
			{
			case EventMode.All:
			case EventMode.Update:
				CheckAndRaiseFoundEnemy ();
				break;
			}
		}

	}
}