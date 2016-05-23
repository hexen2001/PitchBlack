using UnityEngine;
using System.Collections;

namespace Demo4
{
	public abstract class Cmd : MonoBehaviour
	{
		public float delay = 0f;
		public void Do()
		{
			if (0f < delay)
			{
				this.Call (OnDo, delay);
			}
			else
			{
				OnDo ();
			}
		}
		protected abstract void OnDo ();
	}
}