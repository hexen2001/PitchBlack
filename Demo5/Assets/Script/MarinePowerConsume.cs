using UnityEngine;
using System.Collections;


public class MarinePowerConsume : OngoingEffect
{
	protected override int Value
	{
		get
		{
			return marine.power;
		}
		set
		{
			marine.power = value;
		}
	}
	protected override int ValueMax
	{
		get
		{
			return marine.powerMax;
		}
	}
	protected override void Update()
	{
		if( marine.lightCount == 0 && marine.powerful )
		{
			base.Update();
		}
	}
}
