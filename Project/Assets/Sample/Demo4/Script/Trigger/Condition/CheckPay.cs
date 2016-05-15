using UnityEngine;
using System.Collections;

namespace Demo4
{
	public class CheckPay : Condition
	{
		public PayPair[] pairs;
		protected override bool OnCheck ()
		{
			return Manager.main.game.CheckPay(pairs);
		}
	}
}