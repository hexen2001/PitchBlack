using UnityEngine;
using System.Collections;

namespace Demo4
{
	/// <summary>
	/// 道具
	/// 表示某种资源、属性或数值
	/// 游戏中一切可计量的值都是道具
	/// </summary>
	[System.Serializable]
	public class ItemPair
	{
		public ItemPair()
		{
			type = ItemType.Unknown;
			amount = 0;
		}
		public ItemPair(ItemType inType, int inValue)
		{
			type = inType;
			amount = inValue;
		}
		public ItemPair ToInverse()
		{
			return new ItemPair( type, -amount );
		}
		public ItemType type;
		public int amount;
	}
}