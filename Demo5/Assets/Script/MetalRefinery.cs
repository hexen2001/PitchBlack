using UnityEngine;
using System.Collections;

public class MetalRefinery : Refinery
{
	protected override int Value
	{
		get
		{
			return Manager.main.game.metal;
		}
		set
		{
			Manager.main.game.metal = value;
		}
	}
	protected override int ValueMax
	{
		get
		{
			return 500;
		}
	}

}
