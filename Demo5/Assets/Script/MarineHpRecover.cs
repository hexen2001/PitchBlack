using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MarineHpRecover : OngoingEffect
{
	protected override int Value
	{
		get
		{
			return self.hp;
		}
		set
		{
			self.hp = value;
		}
	}
	protected override int ValueMax
	{
		get
		{
			return self.hpMax;
		}
	}
	protected override void Update()
	{
		if( marine.isLife && marine.lightingOrPowerful )
		{
			base.Update();
		}
	}
}
