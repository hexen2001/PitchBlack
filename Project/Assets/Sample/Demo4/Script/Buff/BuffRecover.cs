using UnityEngine;
using System.Collections;

namespace Demo4
{
	public class BuffAdd : Buff
	{
		public ItemPair amount;
		protected void Add(ItemPair pair)
		{
			if( self != null )
			{
				self.items.AddItem( pair );
			}
		}
	}
	/// <summary>
	/// 状态，能量回复
	/// </summary>
	public class BuffRecover : BuffAdd
	{
		public float intervals = 1f;
		IEnumerator Start()
		{
			for( ; ; )
			{
				yield return new WaitForSeconds( intervals );
				Add( amount );
			}
		}
	}
}