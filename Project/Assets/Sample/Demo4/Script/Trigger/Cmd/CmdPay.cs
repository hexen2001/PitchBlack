using UnityEngine;
using System.Collections;

namespace Demo4
{
	[System.Serializable]
	public class PayPair
	{
		public PayPair()
		{
		}
		public PayPair(ResType inType, int inValue )
		{
			type = inType;
			value = inValue;
		}
		public ResType type;
		public int value;
	}
	public class CmdPay : Cmd
	{
		PayPair[] pairs = null;
		protected override void OnDo()
		{
			foreach(var pair in pairs)
			{
				Manager.main.game.Add (new PayPair(pair.type, pair.value));
			}
		}
	}
}