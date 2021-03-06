﻿using UnityEngine;
using System.Collections;

public abstract class Refinery : OngoingEffectBase
{
}
public class PowerRefinery : Refinery
{
	protected override int Value
	{
		get
		{
			return Manager.main.score.power;
		}
		set
		{
			Manager.main.score.power = value;
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
