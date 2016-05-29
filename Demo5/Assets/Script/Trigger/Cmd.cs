using UnityEngine;
using System.Collections;

public abstract class Cmd : MonoBehaviour
{
	public float delay = 0f;
	[ContextMenu("Do")]
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