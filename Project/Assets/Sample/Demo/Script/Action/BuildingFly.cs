// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Pitch Black")]
	public class BuildingFly : ActionBase<Building>
	{
		public enum To
		{
			Fly,
			Land,
		}
		public To to = To.Fly;
		public override void OnLogic()
		{
			if (to == To.Fly)
			{
			}
			else
			{
				
			}
		}
	}
}