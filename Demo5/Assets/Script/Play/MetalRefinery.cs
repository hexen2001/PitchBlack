using UnityEngine;
using System.Collections;

public class MetalRefinery : Refinery
{
	protected override int Value
	{
		get
		{
			return Manager.main.score.metal;
		}
		set
		{
			Manager.main.score.metal = value;
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
