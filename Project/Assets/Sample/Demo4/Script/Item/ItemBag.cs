﻿using UnityEngine;
using System.Collections.Generic;

namespace Demo4
{
	/// <summary>
	/// 道具容器
	/// </summary>
	[System.Serializable]
	public class ItemBag
	{
		public void AddItem(ItemPair pair)
		{
			AddItem( pair.type, pair.amount );
		}
		public void AddItem(ItemType type, int value)
		{
			var result = m_itemList.Find( obj => obj.type == type );
			if( result != null )
			{
				result.amount += value;
			}
			else
			{
				m_itemList.Add( new ItemPair( type, value ) );
			}
		}
		public bool HasItem(ItemType type)
		{
			return Get( type ) > 0;
		}
		public bool HasItem(params ItemPair[] pairs)
		{
			foreach(var pair in pairs)
			{
				if( Get( pair.type ) < pair.amount )
				{
					return false;
				}
			}
			return true;
		}
		public bool ConsumeItem(ItemPair pair)
		{
			return true;
		}
		public int Get(ItemType type)
		{
			var pair = m_itemList.Find( obj => obj.type == type );
			if( pair != null )
			{
				return pair.amount;
			}
			else
			{
				return 0;
			}
		}
		public void Set(ItemType type, int value)
		{
			var result = m_itemList.Find( obj => obj.type == type );
			if( result != null )
			{
				result.amount = value;
			}
			else
			{
				m_itemList.Add( new ItemPair( type, value ) );
			}
		}
		[SerializeField]
		private List<ItemPair> m_itemList
			= new List<ItemPair>();
	}
}